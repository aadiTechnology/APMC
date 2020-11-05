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
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public ProductCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategory()
        {
            return await _repositoryContext.ProductCategory.ToListAsync();
        }
    }
}
