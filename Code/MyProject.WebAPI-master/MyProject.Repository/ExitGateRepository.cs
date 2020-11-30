using Microsoft.EntityFrameworkCore;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class ExitGateRepository: RepositoryBase<ParkingCharges>, IExitGateRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ExitGateRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<ParkingCharges>> GetAllCheckInVehicalDetails()
        {
            return await _repositoryContext.ParkingCharges.Where(a => a.OutTime == null).ToListAsync();
        }
    }
}
