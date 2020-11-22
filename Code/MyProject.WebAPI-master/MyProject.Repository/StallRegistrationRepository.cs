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
        public StallRegistrationRepository(RepositoryContext repositoryContext)
      : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
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

        /// <summary>
        /// This method is used to get all stall registration records for approval.
        /// </summary>
        /// <returns></returns>
        /// <Aurthor>Deepali Patil</Aurthor>
        public async Task<IEnumerable<StallRegistrationDto>> GetAllStallRegistration()
        {
            var Result = (from str in _repositoryContext.StallRegistration
                         join au in _repositoryContext.AppUsers
                         on str.UserId equals au.Id
                         join st in _repositoryContext.StallDetails
                         on str.StallId equals st.Id
                         where str.IsApproved == false && str.IsRejected == false
                         select new StallRegistrationDto
                         {
                             Id = str.Id,
                             StallId = str.StallId,
                             UserId = str.UserId,
                             CreatedDate = str.CreatedDate,
                             MerchantName = au.FirstName + au.LastName,
                             MobileNo = au.MobileNo,
                             StallNo = st.StallNo,
                             StallName = st.StallName,
                             StallRegNo = st.StallRegNo,
                             Area = st.Area
                         });
            return await Result.ToListAsync();
        }

        public async Task<IEnumerable<StallRegistrationDto>> GetStallRegistrationById(int Id)
        {
            var Result = (from str in _repositoryContext.StallRegistration
                          join au in _repositoryContext.AppUsers
                          on str.UserId equals au.Id
                          join st in _repositoryContext.StallDetails
                          on str.StallId equals st.Id
                          where str.Id==Id && str.IsApproved == false && str.IsRejected == false
                          select new StallRegistrationDto
                          {
                              Id = str.Id,
                              StallId = str.StallId,
                              UserId = str.UserId,
                              CreatedDate = str.CreatedDate,
                              MerchantName = au.FirstName + au.LastName,
                              MobileNo = au.MobileNo,
                              StallNo = st.StallNo,
                              StallName = st.StallName,
                              StallRegNo = st.StallRegNo,
                              Area = st.Area
                          });
            return await Result.ToListAsync();
        }
    }
}
