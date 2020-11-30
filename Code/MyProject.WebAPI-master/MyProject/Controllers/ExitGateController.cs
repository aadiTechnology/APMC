using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ExitGateOperator")]

    public class ExitGateController : ControllerBase
    {
        public override void InitializeController() { }
        public ExitGateController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }

        public IRepositoryWrapper RepositoryWrapper { get; }
        /// <summary>
        /// This method is used to get all checkin vehical details of current date.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCheckInVehicalDetails")]
        public async Task<JsonResult> GetAllCheckInVehicalDetails()
        {
            return await base.FinalizeMultiple<IEnumerable<ParkingCharges>>(await RepositoryWrapper.ExitGateRepository.GetAllCheckInVehicalDetails());
        }

        /// <summary>
        /// This method is used to get checkin details of selected vehical.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetCheckInVehicalDetailsById")]
        public async Task<JsonResult> GetCheckInVehicalDetailsById(int Id)
        {
            return await base.FinalizeMultiple<IEnumerable<ParkingCharges>>(await RepositoryWrapper.ExitGateRepository.GetCheckInVehicalDetailsById(Id));
        }

        /// <summary>
        /// This method is used to update exit details of selected vehical.
        /// </summary>
        /// <param name="parkingCharges"></param>
        /// <returns></returns>
        [HttpPost("UpdateParkingCharges")]
        public async Task<JsonResult> UpdateParkingCharges([FromBody] ParkingCharges parkingCharges)
        {
            try
            {
                RepositoryWrapper.ExitGateRepository.UpdateParkingCharges(parkingCharges);
                return await base.FinalizeMessage("Vehical exit succesfully");
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in ParkingCharges Update : " + ex, 401);
            }
        }
    }
}
