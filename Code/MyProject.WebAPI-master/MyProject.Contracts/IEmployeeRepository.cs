using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        PagedList<Employee> GetEmployees(EmployeeParameters employeeParameters);
    }
}
