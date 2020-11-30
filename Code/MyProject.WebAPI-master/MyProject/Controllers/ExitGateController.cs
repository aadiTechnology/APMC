using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExitGateController : ControllerBase
    {
        public override void InitializeController() { }
        public ExitGateController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }
        [HttpGet("GetAllCheckInVehicalDetails")]
        public async Task<JsonResult> GetAllCheckInVehicalDetails()
        {
            return await base.FinalizeMultiple<IEnumerable<ParkingCharges>>(await RepositoryWrapper.ExitGateRepository.GetAllCheckInVehicalDetails());
        }
    }
}
