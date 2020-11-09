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
    public class StallProductCategoriesRepository : RepositoryBase<StallProductCategories>, IStallProductCategoriesRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public Boolean StallProductCategories(List<int> Category, int StallId)
        {
            Category.ForEach(a =>
            {
                var StallProductCategories = new StallProductCategories
                {

                    StallRegistrationId = StallId,
                    Category = a,
                };
            _repositoryContext.Add(StallProductCategories);
            _repositoryContext.SaveChanges();
            });
            return true;
        }
        public StallProductCategoriesRepository(RepositoryContext repositoryContext)
       : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
    }
}
