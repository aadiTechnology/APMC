using System;
using System.Collections.Generic;
using System.Text;
using MyProject.Entities.Models;
using MyProject.Contracts;
using MyProject.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace MyProject.Repository
{
    public class UnitsRepository : RepositoryBase<Units>, IUnitsRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public UnitsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Units>> GetUnits()
        {
            return await _repositoryContext.Units.ToListAsync();
        }
    }
}
