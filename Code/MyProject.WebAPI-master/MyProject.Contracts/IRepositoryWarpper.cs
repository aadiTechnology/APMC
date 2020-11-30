using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Contracts
{
    interface IRepositoryWarpper
    {
    }
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        IAppUsersRepository AppUsers { get; set; }
        IAppUsersRepository AppUserRoles { get; set; }
        IStallDetailsRepository StallDetails { get; set; }
        IProductCategoryRepository ProductCategory { get; set; }
        IStallRegistrationRepository StallRegistration { get; set; }
        IStallProductCategoriesRepository StallProductCategories { get; set; }
        IIndentRepository IndentDetails { get; set; }
        IProductRepository Product { get; set; }
        IUnitsRepository Units { get; set; }
        IEntryCheckInDetailsRepository EntryCheckInDetails { get; set; }
        void Save();
    }
}
