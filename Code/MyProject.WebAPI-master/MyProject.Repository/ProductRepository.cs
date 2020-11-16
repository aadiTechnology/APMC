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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Product>> GetProducts(int CategoryId)
        {
            //return await _repositoryContext.StallDetails.ToListAsync();
            return await _repositoryContext.Product.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }
    }
}
