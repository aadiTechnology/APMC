using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entities.Models;
namespace MyProject.Contracts
{

    public interface IProductRepository : IRepositoryBase<Product>
    {
        //Product GetProducts(int CategoryId);
        Task<IEnumerable<Product>> GetProducts(int CategoryId);
    }
}