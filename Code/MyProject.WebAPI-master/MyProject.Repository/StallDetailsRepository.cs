using System;
using System.Collections.Generic;
using System.Text;
using MyProject.Entities.Models;
using MyProject.Contracts;
using MyProject.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<StallDetails>> GetAllStallDetails()
        {
            return await _repositoryContext.StallDetails.ToListAsync();
        }
    }
}
