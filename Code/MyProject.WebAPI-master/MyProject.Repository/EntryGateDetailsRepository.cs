using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Repository
{
    public class EntryGateDetailsRepository : RepositoryBase<IndentDetails>, IEntryGateDetailsRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public EntryGateDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ParkingCharges AddEntryCheckInDetails(IndentDetails indentDetails, List<ParkingCharges> parkingCharges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IndentDetails>> GetAllNotScannedIndent()
        {
            return await _repositoryContext.IndentDetails.Where(x => x.IsScanned == false && x.CreatedDate.Date == DateTime.Now.Date).ToListAsync();
        }

        public async Task<IEnumerable<IndentDetails>> IndentDetailsByOrderNo(string orderNo)
        {
            var Result = (from Idetails in _repositoryContext.IndentDetails
                          where Idetails.OrderNo == orderNo && Idetails.IsScanned == false && 
                          Idetails.CreatedDate.Date == DateTime.Now.Date
                          select new IndentDetails
                          {
                              Id = Idetails.Id,
                              OrderNo = Idetails.OrderNo,
                              SupplierName = Idetails.SupplierName,
                              SupplierNo = Idetails.SupplierNo,
                              VehicleNo = Idetails.VehicleNo,
                              DriverName = Idetails.DriverName,
                              DriverNo = Idetails.DriverNo
                          });
            return await Result.ToListAsync();
        }
    }
}
