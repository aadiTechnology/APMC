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
        /// This method is used to get all checkin vehicle details of current date.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCheckInVehicleDetails")]
        public async Task<JsonResult> GetAllCheckInVehicleDetails()
        {
            return await base.FinalizeMultiple<IEnumerable<ParkingCharges>>(await RepositoryWrapper.ExitGateRepository.GetAllCheckInVehicleDetails());
        }

        /// <summary>
        /// This method is used to get checkin details of selected vehicle.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetCheckInVehicleDetailsById")]
        public async Task<JsonResult> GetCheckInVehicleDetailsById(int Id)
        {
            return await base.FinalizeMultiple<IEnumerable<ParkingCharges>>(await RepositoryWrapper.ExitGateRepository.GetCheckInVehicleDetailsById(Id));
        }

        /// <summary>
        /// This method is used to update exit details of selected vehicle.
        /// </summary>
        /// <param name="parkingCharges"></param>
        /// <returns></returns>
        [HttpPost("UpdateParkingCharges")]
        public async Task<JsonResult> UpdateParkingCharges([FromBody] ParkingCharges parkingCharges)
        {
            try
            {
                RepositoryWrapper.ExitGateRepository.UpdateParkingCharges(parkingCharges);
                return await base.FinalizeMessage("Vehicle exit succesfully");
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in ParkingCharges Update : " + ex, 401);
            }
        }
    }
}
