using System;
using System.Collections.Generic;
using System.Text;
using MyProject.Entities.Models;
using MyProject.Contracts;
using MyProject.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyProject.Repository
{
    public class StallDetailsRepository : RepositoryBase<StallDetails>, IStallDetailsRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public StallDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public StallDetails UpdateStallAssigned(int StallId)
        {
            var updateStallAssigned = _repositoryContext.StallDetails.FirstOrDefault(a => a.Id == StallId);
            updateStallAssigned.IsAssigned = true;
            _repositoryContext.StallDetails.Update(updateStallAssigned);
            _repositoryContext.SaveChanges();
            return updateStallAssigned;
        }


        public async Task<IEnumerable<StallDetails>> GetAllStallDetails()
        {
            //return await _repositoryContext.StallDetails.ToListAsync();
            return await _repositoryContext.StallDetails.Where(a => a.IsAssigned == false).ToListAsync();

        }
    }
}
