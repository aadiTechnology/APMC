using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IExitGateRepository: IRepositoryBase<ParkingCharges>
    {
        Task<IEnumerable<ParkingCharges>> GetAllCheckInVehicleDetails();
        Task<IEnumerable<ParkingCharges>> GetCheckInVehicleDetailsById(int Id);
        ParkingCharges UpdateParkingCharges(ParkingCharges parkingCharges);
    }
}
