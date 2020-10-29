using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }
        public PagedList<Employee> GetEmployees(EmployeeParameters employeeParameters)
        {
            return PagedList<Employee>.ToPagedList(FindAll().OrderBy(em => em.Id),
                employeeParameters.PageNumber,
                employeeParameters.PageSize);
        }
    }
}
