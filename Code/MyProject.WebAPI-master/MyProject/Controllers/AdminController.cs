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
        public override void InitializeController()
        {

        }
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
        public async Task<JsonResult> GetAllStallRegistration()
        {
            return await base.FinalizeMultiple<IEnumerable<StallRegistration>>(await RepositoryWrapper.StallRegistration.GetAllStallRegistration()); 
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
        public async Task<JsonResult> UpdateStallRegistration([FromBody] StallRegistrationDto stallregisterDto)
        {
            try
            {
                if (stallregisterDto.IsApproved == true && stallregisterDto.IsRejected != true)
                {
                    RepositoryWrapper.StallDetails.UpdateStallAssigned(stallregisterDto.StallId);
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return await base.FinalizStatusCodeeMessage("StallRegistration Sucessfully Approved",200);
                }
                else if (stallregisterDto.IsRejected == true && stallregisterDto.IsApproved != true && stallregisterDto.RejectReason != null && stallregisterDto.RejectReason != "")
                {
                    RepositoryWrapper.StallRegistration.UpdateStallRegistrationAdmin(stallregisterDto.Id, stallregisterDto.ApproveBy, stallregisterDto.IsApproved, stallregisterDto.IsRejected, stallregisterDto.RejectReason);
                    return await base.FinalizStatusCodeeMessage("StallRegistration Rejected",200);
                }
                else
                {
                    return await base.FinalizStatusCodeeMessage("Error: Approved and Rejected Both Should not be true at same time  Or If Rejected Enter Reject Reason Compulsory",200);
                }


                
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in Stall Update : " + ex,401);
            }
        }
    }
}
