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
           //var result= _repositoryContext.ProductCategory.Join(_repositoryContext.StallProductCategories, r => r.Category, p => p.Id, (r, p) => new { p.Id, p.Category});
            //var result = (from c in _repositoryContext.ProductCategory
            //              join s in _repositoryContext.StallProductCategories on s.Category equals s.Id
            //              new ProductCategory { Id = c.Id, Category = c.Category }).ToList();
           // return result;
             return await _repositoryContext.ProductCategory.ToListAsync();
        }
    }
}
