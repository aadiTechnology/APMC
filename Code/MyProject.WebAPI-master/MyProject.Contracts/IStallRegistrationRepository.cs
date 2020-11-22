using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;

namespace MyProject.Contracts
{
    public interface IStallRegistrationRepository:IRepositoryBase<StallRegistration>
    {
        StallRegistration StallRegistration(int UserId, int StallId);
        StallRegistration UpdateStallRegistrationAdmin(int Id, int ApproveBy, bool IsApproved, bool IsRejected, string RejectReason);
        
        Task<IEnumerable<StallRegistrationDto>> GetAllStallRegistration();
        Task<IEnumerable<StallRegistrationDto>> GetStallRegistrationById(int Id);

    }

}
