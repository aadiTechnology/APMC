using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entities.Models;

namespace MyProject.Contracts
{
    public interface IStallProductCategoriesRepository : IRepositoryBase<StallProductCategories>
    {
        Boolean StallProductCategories(List<int> Category,int StallId);
    }
}
