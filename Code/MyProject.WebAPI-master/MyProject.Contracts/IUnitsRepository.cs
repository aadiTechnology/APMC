using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entities.Models;
namespace MyProject.Contracts
{

    public interface IUnitsRepository : IRepositoryBase<Units>
    {
        //Product GetProducts(int CategoryId);
        Task<IEnumerable<Units>> GetUnits();
    }
}