using MyProject.Contracts;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repository
{
    public class RepositoryWarpper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IEmployeeRepository _employee;
        private IAppUsersRepository _appUsers;
        
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public IAppUsersRepository AppUsers
        {
            get
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                }
                return _appUsers;
            }
            set
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                };
            }
            
        }
        public IAppUsersRepository AppUserRoles
        {
            get
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                }
                return _appUsers;
            }
            set
            {
                if (_appUsers == null)
                {
                    _appUsers = new AppUsersRepository(_repoContext);
                };
            }

        }
        public RepositoryWarpper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
