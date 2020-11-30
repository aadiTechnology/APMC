using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class EntryCheckInDetailsRepository : RepositoryBase<IndentDetails>, IEntryCheckInDetailsRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public EntryCheckInDetailsRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ParkingCharges AddEntryCheckInDetails(IndentDetails indentDetails, List<ParkingCharges> parkingCharges)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IndentDetails>> IEntryCheckInDetailsRepository.GetAllNotScannedIndent()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IndentDetails>> IEntryCheckInDetailsRepository.GetAllScannedIndent()
        {
            throw new NotImplementedException();
        }
    }
}
