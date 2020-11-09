using Microsoft.EntityFrameworkCore;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class StallRegistrationRepository : RepositoryBase<StallRegistration>, IStallRegistrationRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public StallRegistration StallRegistration(int UserId, int StallId)
        {
            try
            {
                var stallregistration = new StallRegistration
                {
                    UserId = UserId,
                    StallId = StallId,
                    IsApproved = false,
                    IsRejected = false,
                    CreatedDate = DateTime.UtcNow
                };
                _repositoryContext.Add(stallregistration);
                _repositoryContext.SaveChanges();
                return stallregistration;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public StallRegistration UpdateStallRegistrationAdmin(int Id, int ApproveBy, bool IsApproved, bool IsRejected, string RejectReason)
        {
            try
            {
                var updateStallRegistrationAdmin = _repositoryContext.StallRegistration.FirstOrDefault(a => a.Id == Id);
                updateStallRegistrationAdmin.IsApproved = IsApproved;
                updateStallRegistrationAdmin.IsRejected = IsRejected;
                updateStallRegistrationAdmin.ApproveBy = ApproveBy;
                updateStallRegistrationAdmin.ApprovedDate = DateTime.UtcNow;
                updateStallRegistrationAdmin.RejectReason = RejectReason;
                _repositoryContext.StallRegistration.Update(updateStallRegistrationAdmin);
                _repositoryContext.SaveChanges();
                return updateStallRegistrationAdmin;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<StallRegistration>> GetAllStallRegistration()
        {
            return await _repositoryContext.StallRegistration.ToListAsync();
          //  return await _repositoryContext.StallRegistration.Where(a => a.IsApproved == false).ToListAsync();

        }
        public StallRegistrationRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
