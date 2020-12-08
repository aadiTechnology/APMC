using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class IndentRepository : RepositoryBase<IndentDetails>, IIndentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IndentRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IndentDetails AddIndent(IndentDetails indentDetails, List<IndentProducts> indentProducts)
        {
            try
            {
                indentDetails.OrderNo = GetOrderId();
                indentDetails.CreatedDate = DateTime.Now;
                _repositoryContext.IndentDetails.Add(indentDetails);
                _repositoryContext.SaveChanges();
                var id = GetIndentId();
                foreach (IndentProducts indentProduct in indentProducts)
                {
                    indentProduct.IndentId = id;
                }
                _repositoryContext.IndentProducts.AddRange(indentProducts);
                _repositoryContext.SaveChanges();
                GenerateQRCode(id.ToString(), indentDetails.CreatedBy.ToString(), indentDetails.DriverNo.ToString());
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IndentDetails Update(IndentDetails indentDetails)
        {
            try
            {
                _repositoryContext.IndentDetails.Update(indentDetails);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string GetOrderId()
        {
            string orderNo = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.OrderNo).FirstOrDefault();
            if (orderNo == null)
            {
                orderNo = "IndNo-1";
            }
            else
            {
                orderNo = "IndNo-" + (Convert.ToInt32(orderNo.Split('-')[1].Trim()) + 1);
            }
            return orderNo;
        }

        public int GetIndentId()
        {
            int id = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            return id;
        }

        public IndentDetails GetIndent(int indentId, int merchantId, string driverId)
        {
            IndentDetails indentDetails = _repositoryContext.IndentDetails.Where(a => a.Id == indentId && a.CreatedBy == merchantId && a.DriverNo == driverId).FirstOrDefault();
            return indentDetails;
        }
        public List<IndentDetails> GetIndentByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _repositoryContext.IndentDetails.Where(a => a.CreatedDate >= fromDate && a.CreatedDate <= toDate).ToList();
        }
        private byte[] getByte(string path)
        {
            Image img = Image.FromFile(path);
            return (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
        }
        public byte[] GenerateQRCode(string indentId, string merchantId, string driverId)
        {
            IndentDetails indentDetails = GetIndent(int.Parse(indentId));
            //if (string.IsNullOrWhiteSpace(indentDetails.OrderNo)|| string.IsNullOrWhiteSpace(indentDetails.DriverNo)||)
            //{

            //}
            string encodeString = Base64Encode(indentId + "|" + merchantId + "|" + driverId);
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(encodeString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] array = BitmapToBytesCode(qrCodeImage);
            //File.WriteAllBytes(_repositoryContext.GlobalConfigurations.Where(a => a.Key == "QRPath").FirstOrDefault().Value + indentId + merchantId + driverId + ".png", array);
            indentDetails.QrId = "data:image/png;base64," + Convert.ToBase64String(array, 0, array.Length);
            _repositoryContext.IndentDetails.Update(indentDetails);
            _repositoryContext.SaveChanges();
            return array;
        }

        private Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public List<IndentMerchantDto> GetIndentWithMerchantName()
        {
            var Result = (from Idetails in _repositoryContext.IndentDetails
                          join au in _repositoryContext.AppUsers
                          on Idetails.CreatedBy equals au.Id
                          where Idetails.IsScanned == false
                          select new IndentMerchantDto
                          {
                              Id = Idetails.Id,
                              OrderNo = Idetails.OrderNo,
                              MerchantName = au.FirstName + " " + au.LastName
                              //StallName = _repositoryContext.StallDetails.Where(a => a.Id == sr.StallId).FirstOrDefault().StallName,

                          }).ToList();
            return Result;
        }



        public IndentDetails GetIndent(int indentID)
        {
            IndentDetails indentDetails = _repositoryContext.IndentDetails.Where(a => a.Id == indentID).FirstOrDefault();
            return indentDetails;
        }
        public IndentDetailsDto GetIndentDetails(int indentID)
        {
            var indentDetails = (from Idetails in _repositoryContext.IndentDetails
                                 join au in _repositoryContext.AppUsers
                                 on Idetails.CreatedBy equals au.Id
                                 where Idetails.Id == indentID
                                 select new IndentDetailsDto
                                 {
                                     IndentDetails = Idetails,
                                     MerchantDetails = au,
                                 }).FirstOrDefault();

            List<IndentProducts> indentProducts = new List<IndentProducts>();
            indentDetails.IndentProducts = _repositoryContext.IndentProducts.Where(a => a.IndentId == indentDetails.IndentDetails.Id).ToList();
            indentDetails.DriverDetails = _repositoryContext.AppUsers.Where(a => a.Id == indentDetails.IndentDetails.DriverId).FirstOrDefault();
            var stalls = (from Idetails in _repositoryContext.IndentDetails
                          join stallReg in _repositoryContext.StallRegistration
                           on Idetails.CreatedBy equals stallReg.UserId
                          join stallDetails in _repositoryContext.StallDetails
                        on stallReg.StallId equals stallDetails.Id
                          where Idetails.Id == indentDetails.IndentDetails.Id
                          select new IndentDetailsDto
                          {
                              StallDetails = stallDetails
                          }
       ).FirstOrDefault();
            if (stalls != null)
            {
                indentDetails.StallDetails = stalls.StallDetails;
            }
            return indentDetails;
        }
        public List<IndentDetailsDto> GetIndentDetailsByMerchantID(int merchant)
        {
            var indentDetails = (from Idetails in _repositoryContext.IndentDetails
                                 join au in _repositoryContext.AppUsers
                                 on Idetails.CreatedBy equals au.Id
                                 where (Idetails.CreatedBy == merchant && Idetails.RollId == 2) || Idetails.AppovedBy == merchant
                                 select new IndentDetailsDto
                                 {
                                     IndentDetails = Idetails,
                                     MerchantDetails = au,
                                 }).ToList();
            foreach (var item in indentDetails)
            {
                List<IndentProducts> indentProducts = new List<IndentProducts>();
                item.IndentProducts = _repositoryContext.IndentProducts.Where(a => a.IndentId == item.IndentDetails.Id).ToList();
                item.DriverDetails = _repositoryContext.AppUsers.Where(a => a.Id == item.IndentDetails.DriverId).FirstOrDefault();
                var stalls = (from Idetails in _repositoryContext.IndentDetails
                              join stallReg in _repositoryContext.StallRegistration
                               on Idetails.CreatedBy equals stallReg.UserId
                              join stallDetails in _repositoryContext.StallDetails
                            on stallReg.StallId equals stallDetails.Id
                              where Idetails.Id == item.IndentDetails.Id
                              select new IndentDetailsDto
                              {
                                  StallDetails = stallDetails
                              }
           ).FirstOrDefault();
                if (stalls != null)
                {
                    item.StallDetails = stalls.StallDetails;
                }


            }

            return indentDetails.OrderByDescending(a => a.IndentDetails.CreatedDate).ToList();
        }
        public List<IndentDetailsDto> GetIndentDetailsByDriverID(int driverId)
        {
            var indentDetails = (from Idetails in _repositoryContext.IndentDetails
                                 join au in _repositoryContext.AppUsers
                                 on Idetails.CreatedBy equals au.Id
                                 where Idetails.CreatedBy == driverId
                                 select new IndentDetailsDto
                                 {
                                     IndentDetails = Idetails,
                                     MerchantDetails = au,
                                 }).ToList();
            foreach (var item in indentDetails)
            {
                List<IndentProducts> indentProducts = new List<IndentProducts>();
                item.IndentProducts = _repositoryContext.IndentProducts.Where(a => a.IndentId == item.IndentDetails.Id).ToList();
                item.DriverDetails = _repositoryContext.AppUsers.Where(a => a.Id == item.IndentDetails.DriverId).FirstOrDefault();
                var stalls = (from Idetails in _repositoryContext.IndentDetails
                              join stallReg in _repositoryContext.StallRegistration
                               on Idetails.CreatedBy equals stallReg.UserId
                              join stallDetails in _repositoryContext.StallDetails
                            on stallReg.StallId equals stallDetails.Id
                              where Idetails.Id == item.IndentDetails.Id
                              select new IndentDetailsDto
                              {
                                  StallDetails = stallDetails
                              }
           ).FirstOrDefault();
                if (stalls != null)
                {
                    item.StallDetails = stalls.StallDetails;
                }


            }

            return indentDetails.OrderByDescending(a => a.IndentDetails.CreatedDate).ToList();
        }
        public IndentDetailsDto GetIndent(int indentId, int merchantId, int driverId)
        {

            IndentDetails indentDetails = _repositoryContext.IndentDetails.Where(a => a.Id == indentId && a.CreatedBy == merchantId && a.DriverId == driverId).FirstOrDefault();
            var indentDetailsDto = (from Idetails in _repositoryContext.IndentDetails
                                    join au in _repositoryContext.AppUsers
                                    on Idetails.CreatedBy equals au.Id
                                    where Idetails.Id == indentDetails.Id
                                    select new IndentDetailsDto
                                    {
                                        IndentDetails = Idetails,
                                        MerchantDetails = au,
                                    }).FirstOrDefault();

            List<IndentProducts> indentProducts = new List<IndentProducts>();
            indentDetailsDto.IndentProducts = _repositoryContext.IndentProducts.Where(a => a.IndentId == indentDetailsDto.IndentDetails.Id).ToList();
            indentDetailsDto.DriverDetails = _repositoryContext.AppUsers.Where(a => a.Id == indentDetailsDto.IndentDetails.DriverId).FirstOrDefault();
            var stalls = (from Idetails in _repositoryContext.IndentDetails
                          join stallReg in _repositoryContext.StallRegistration
                           on Idetails.CreatedBy equals stallReg.UserId
                          join stallDetails in _repositoryContext.StallDetails
                        on stallReg.StallId equals stallDetails.Id
                          where Idetails.Id == indentDetailsDto.IndentDetails.Id
                          select new IndentDetailsDto
                          {
                              StallDetails = stallDetails
                          }
       ).FirstOrDefault();
            if (stalls != null)
            {
                stalls.StallDetails = stalls.StallDetails;
            }
            return indentDetailsDto;
        }

    }
}
