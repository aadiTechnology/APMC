using Microsoft.EntityFrameworkCore;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class ExitGateRepository: RepositoryBase<ParkingCharges>, IExitGateRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ExitGateRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<ParkingCharges>> GetAllCheckInVehicleDetails()
        {
            try
            {
                var a= await _repositoryContext.ParkingCharges.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ParkingCharges>> GetCheckInVehicleDetailsById(int Id)
        {
            try
            {
                var parkingCharges=await _repositoryContext.ParkingCharges.Where(a => a.Id == Id).ToListAsync();
                foreach (var parkingCharge in parkingCharges)
                {
                    var vehicalMaster = await _repositoryContext.VehicleTypeMaster.Where(a => a.Id == parkingCharge.VehicleTypeId).FirstOrDefaultAsync();
                    parkingCharge.OutTime = DateTime.UtcNow;
                    TimeSpan ts = parkingCharge.OutTime.Value -parkingCharge.InTime.Value;
                    parkingCharge.ExtraTimeFee = ts.Hours * (vehicalMaster.ExtraTimeFee/ vehicalMaster.ExtraTime);
                }
                return parkingCharges;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ParkingCharges UpdateParkingCharges(ParkingCharges parkingCharges)
        {
            try
            {
                var UpdateParkingCharges = _repositoryContext.ParkingCharges.FirstOrDefault(a => a.Id == parkingCharges.Id);
                UpdateParkingCharges.OutTime = parkingCharges.OutTime;
                UpdateParkingCharges.NoParkingFee = parkingCharges.NoParkingFee;
                UpdateParkingCharges.ExtraTimeFee = parkingCharges.ExtraTimeFee;
                UpdateParkingCharges.ExtraTime = parkingCharges.ExtraTime;
                UpdateParkingCharges.FineCharges = parkingCharges.FineCharges;
                UpdateParkingCharges.UpdatedById = parkingCharges.UpdatedById;
                UpdateParkingCharges.UpdatedDate = DateTime.UtcNow;

                _repositoryContext.ParkingCharges.Update(UpdateParkingCharges);
                _repositoryContext.SaveChanges();
                return UpdateParkingCharges;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
