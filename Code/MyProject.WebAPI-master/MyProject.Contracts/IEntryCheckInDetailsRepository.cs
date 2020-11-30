using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IEntryCheckInDetailsRepository : IRepositoryBase<IndentDetails>
    {
        Task<IEnumerable<IndentDetails>> GetAllScannedIndent();
        Task<IEnumerable<IndentDetails>> GetAllNotScannedIndent();
        ParkingCharges AddEntryCheckInDetails(IndentDetails indentDetails, List<ParkingCharges> parkingCharges);
    }
}
