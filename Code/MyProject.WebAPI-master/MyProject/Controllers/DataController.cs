using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using Newtonsoft.Json;

namespace MyProject.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController(IRepositoryWrapper repositoryWrapper,ILoggerManager logger,IMapper mapper)
        {
            RepositoryWrapper = repositoryWrapper;
            _logger = logger;
            this._mapper = mapper;
        }

        public IRepositoryWrapper RepositoryWrapper { get; }

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        // GET: api/<DataController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    //Testing Logging

        //    //_logger.LogInfo("Here is info message from the controller.");
        //    //_logger.LogDebug("Here is debug message from the controller.");
        //    //_logger.LogWarn("Here is warn message from the controller.");
        //    //_logger.LogError("Here is error message from the controller.");

        //    //Testing Global Exceptions
        //    //_logger.LogInfo("Fetching all the Emlployees from the storage");           
        //    //throw new Exception("Exception while fetching all the students from the storage.");           

        //    //Getting Data
        //    var employees= RepositoryWrapper.Employee.FindAll();
        //    return Ok(employees);
        //    //return RepositoryWrapper.Employee.FindByCondition(x => x.Id.Equals(2));            

        //}
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees([FromQuery] EmployeeParameters employeeParameters)
        {
            var employees = RepositoryWrapper.Employee.GetEmployees(employeeParameters);

            var metadata = new
            {
                employees.TotalCount,
                employees.PageSize,
                employees.CurrentPage,
                employees.TotalPages,
                employees.HasNext,
                employees.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            var employeeResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            _logger.LogInfo($"Returned {employees.TotalCount} owners from database.");

            return Ok(employeeResult);
        }
    }
}
