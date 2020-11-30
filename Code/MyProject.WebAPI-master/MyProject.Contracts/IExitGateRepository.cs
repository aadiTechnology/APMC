using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IExitGateRepository: IRepositoryBase<ParkingCharges>
    {
        Task<IEnumerable<ParkingCharges>> GetAllCheckInVehicalDetails();
        Task<IEnumerable<ParkingCharges>> GetCheckInVehicalDetailsById(int Id);
        ParkingCharges UpdateParkingCharges(ParkingCharges parkingCharges);
    }
}
