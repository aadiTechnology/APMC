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

        public async Task<IEnumerable<EntryCheckInDetailsDto>> IndentDetailsById(int id)
        {
            try
            {
                var Result = (from Idetails in _repositoryContext.IndentDetails
                              join sr in _repositoryContext.StallRegistration
                              on Idetails.Id equals sr.UserId
                              join au in _repositoryContext.AppUsers
                              on sr.UserId equals au.Id
                              join sd in _repositoryContext.StallDetails
                              on sr.StallId equals sd.Id
                              join ip in _repositoryContext.IndentProducts
                              on Idetails.Id equals ip.IndentId
                              join pc in _repositoryContext.ProductCategory
                              on ip.ProductId equals pc.Id
                              join p in _repositoryContext.Product
                              on pc.Id equals p.CategoryId
                              join u in _repositoryContext.Units
                              on ip.UnitId equals u.Id
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
                                  ProductName = p.ProductName,
                                  ProductCategory = pc.Category,
                                  StallNo = sd.StallNo,
                                  StallName = sd.StallName,
                                  ProductQuantity = ip.ProductQuantity,
                                  Unit = u.Unit
                              });
                return await Result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
