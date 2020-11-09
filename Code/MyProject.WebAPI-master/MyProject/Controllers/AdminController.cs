using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }

        [HttpGet("GetAllStallRegistration")]
        public async Task<IEnumerable<StallRegistration>> GetAllStallRegistration()
        {
            return await RepositoryWrapper.StallRegistration.GetAllStallRegistration();
        }
        [HttpPost("UpdateStallRegistration")]
        public ActionResult<StallRegistrationDto> UpdateStallRegistration([FromBody] StallRegistrationDto stallregisterDto)
        {
            try
            {
                if (stallregisterDto.IsApproved == true && stallregisterDto.IsRejected != true)
                {
                    RepositoryWrapper.StallDetails.UpdateStallAssigned(stallregisterDto.StallId);
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return Content("Stall Update Sucessfully Approved");
                }
                else if (stallregisterDto.IsRejected == true && stallregisterDto.IsApproved != true && stallregisterDto.RejectReason != null && stallregisterDto.RejectReason != "")
                {
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return Content("Stall Update Sucessfully Rejected");
                }
                else
                {
                    return Content("Error: Approved and Rejected Both Should not be true at same time  Or If Rejected Enter reason Compulsory");
                }


                
            }
            catch (Exception ex)
            {
                return Content("Failure in Stall Update : " + ex);
            }
        }
    }
}
