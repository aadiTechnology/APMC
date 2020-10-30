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
        void Save();
    }
}
