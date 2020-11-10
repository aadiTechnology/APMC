using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repository
{
    public class IndentRepository : RepositoryBase<IndentDetails>, IIndentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IndentRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IndentDetails Add(IndentDetails indentDetails, List<IndentProducts> indentProducts)
        {
            try
            {
                _repositoryContext.IndentDetails.Add(indentDetails);
                _repositoryContext.IndentProducts.AddRange(indentProducts);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public IndentDetails Update(IndentDetails indentDetails)
        {
            try
            {
                _repositoryContext.IndentDetails.Update(indentDetails);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
