using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Entities.DataTransferObjects;

namespace MyProject.Repository
{
    public class EntryGateDetailsRepository : RepositoryBase<IndentDetails>, IEntryGateDetailsRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public EntryGateDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ParkingCharges AddEntryCheckInDetails(int indentId, ParkingCharges parkingCharges)
        {
            try
            {
                _repositoryContext.ParkingCharges.Add(parkingCharges);
                _repositoryContext.SaveChanges();
                var updateindentDetails = _repositoryContext.IndentDetails.FirstOrDefault(a => a.Id == indentId);
                updateindentDetails.QrId = updateindentDetails.QrId;
                updateindentDetails.IsScanned = true;
                _repositoryContext.IndentDetails.Update(updateindentDetails);
                _repositoryContext.SaveChanges();
                return parkingCharges;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IndentDetails>> GetAllNotScannedIndent()
        {
            return await _repositoryContext.IndentDetails.Where(x => x.IsScanned == false && x.CreatedDate.Date == DateTime.Now.Date).ToListAsync();
        }

        public async Task<EntryCheckInDetailsDto> IndentDetailsById(int id)
        {
            try
            {
                var Result = (from Idetails in _repositoryContext.IndentDetails
                              join au in _repositoryContext.AppUsers
                              on Idetails.CreatedBy equals au.Id
                              where Idetails.Id == id && Idetails.IsScanned == false
                              && Idetails.CreatedDate.Date == DateTime.Now.Date
                              select new EntryCheckInDetailsDto
                              {
                                  IndentId = Idetails.Id,
                                  OrderNo = Idetails.OrderNo,   
                                  SupplierName = Idetails.SupplierName,
                                  SupplierNo = Idetails.SupplierNo,
                                  VehicleNo = Idetails.VehicleNo,
                                  DriverName = Idetails.DriverName,
                                  DriverNo = Idetails.DriverNo,
                                  ETADate = Idetails.ETADate,
                                  ETATime = Idetails.ETATime,
                                  StallCreatedBy = au.FirstName +" "+au.LastName,
                                  QrId= Idetails.QrId
                                  //StallName = _repositoryContext.StallDetails.Where(a => a.Id == sr.StallId).FirstOrDefault().StallName,

                              }).FirstOrDefault();
                var res = (from indentProduct in _repositoryContext.IndentProducts
                           join ind in _repositoryContext.IndentDetails
                           on indentProduct.IndentId equals ind.Id
                           where ind.Id == id && ind.IsScanned == false
                                && ind.CreatedDate.Date == DateTime.Now.Date select new{
                                    indent= ind,
                                    product= indentProduct
                                }
                ).ToList();
                var stall = (from Idetails in _repositoryContext.IndentDetails
                             join stallReg in _repositoryContext.StallRegistration
                              on Idetails.CreatedBy equals stallReg.UserId
                             join stallDetails in _repositoryContext.StallDetails
                           on stallReg.StallId equals stallDetails.Id
                           where Idetails.Id == id && Idetails.IsScanned == false
                                && Idetails.CreatedDate.Date == DateTime.Now.Date
                           select new
                           {
                              stallName= stallDetails.StallName
                           }
               ).FirstOrDefault();
                Result.StallName = stall.stallName;
                Result.Products = new List<InedntProducts>();
                foreach (var item in res)
                {
                    InedntProducts inedntProducts = new InedntProducts
                    {
                        ProductCategory= _repositoryContext.ProductCategory.Where(a=>a.Id== item.product.CategoryId).FirstOrDefault().Category,
                        ProductName= item.product.ProductName,
                        ProductQuantity= item.product.ProductQuantity,
                        Unit= _repositoryContext.Units.Where(a=>a.Id==item.product.UnitId).FirstOrDefault().Unit
                    };
                    Result.Products.Add(inedntProducts);
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
