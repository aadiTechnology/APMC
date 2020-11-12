using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        public AdminController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }

        /// <summary>
        /// GetAllStallRegistration() - Dosent need any Parameter to pass 
        /// </summary>
        /// <param></param>
        /// <returns>returns the list of Stall Registeration which are not approved not rejected</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
        [HttpGet("GetAllStallRegistration")]
        public async Task<IEnumerable<StallRegistration>> GetAllStallRegistration()
        {
            return await RepositoryWrapper.StallRegistration.GetAllStallRegistration(); 
        }

        /// <summary>
        /// UpdateStallRegistration - Only admin user can UPdate the Approval and Reject of stall with some other details in StallRegistration table and get status or error in return
        /// The If loop below validate the input data for further process so if approved it also update UpdateStallAssigned in StallDetails table.
        /// </summary>
        /// <param>
        /// Input type Json
        ///  {"Id":3, "StallId":3, "ApproveBy":1006,"IsApproved":true,"IsRejected":false,"RejectReason":""}
        /// </param>
        /// <returns>Returns status/Exception if Sucessfully updated data in table or not</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
        [HttpPost("UpdateStallRegistration")]
        public ActionResult<StallRegistrationDto> UpdateStallRegistration([FromBody] StallRegistrationDto stallregisterDto)
        {
            try
            {
                if (stallregisterDto.IsApproved == true && stallregisterDto.IsRejected != true)
                {
                    RepositoryWrapper.StallDetails.UpdateStallAssigned(stallregisterDto.StallId);
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return Ok("StallRegistration Sucessfully Approved");
                }
                else if (stallregisterDto.IsRejected == true && stallregisterDto.IsApproved != true && stallregisterDto.RejectReason != null && stallregisterDto.RejectReason != "")
                {
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return Ok("StallRegistration Rejected");
                }
                else
                {
                    return Ok("Error: Approved and Rejected Both Should not be true at same time  Or If Rejected Enter Reject Reason Compulsory");
                }


                
            }
            catch (Exception ex)
            {
                return Ok("Error: Failure in Stall Update : " + ex);
            }
        }
    }
}
