using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entities.Models;
namespace MyProject.Contracts
{

   public interface IStallDetailsRepository:IRepositoryBase<StallDetails>
    {
        Task<IEnumerable<StallDetails>> GetAllStallDetails();
        StallDetails UpdateStallAssigned(int StallId);
    }
}
