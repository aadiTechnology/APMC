using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Contracts;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryGateController : ControllerBase
    {
        public override void InitializeController() { }
        public EntryGateController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }

        /// <summary>
        /// Author-Datta(Add Indent details and indent products)
        /// </summary>
        /// <param name="IndentDto"></param>
        /// <returns>Return Indent details if insert successfully</returns>
        [HttpGet("GetAllNotScannedIndent")]
        public async Task<JsonResult> GetAllNotScannedIndent()
        {
            return await base.FinalizeMultiple<IEnumerable<IndentDetails>>(await RepositoryWrapper.EntryCheckInDetails.GetAllNotScannedIndent());
        }

        /// <summary>
        /// Author-Datta(Add Indent details and indent products)
        /// </summary>
        /// <param name="IndentDto"></param>
        /// <returns>Return Indent details if insert successfully</returns>
        [HttpGet("IndentDetailsById")]
        public async Task<JsonResult> IndentDetailsByOrderNo(int id)
        {
            return await base.FinalizeMultiple<IEnumerable<EntryCheckInDetailsDto>>(await RepositoryWrapper.EntryCheckInDetails.IndentDetailsById(id));
        }

        /// <summary>
        /// Author-Datta(Add Indent details and indent products)
        /// </summary>
        /// <param name="IndentDto"></param>
        /// <returns>Return Indent details if insert successfully</returns>
        [HttpPost("AddEntryCheckInDetails")]
        public async Task<JsonResult> AddEntryCheckInDetails([FromBody] EntryCheckInDetailsDto EntryCheckInDetailsDto)
        {
            try
            {
                RepositoryWrapper.EntryCheckInDetails.AddEntryCheckInDetails(EntryCheckInDetailsDto.IndentDetails.Id, EntryCheckInDetailsDto.ParkingCharges);
                return await base.FinalizStatusCodeeMessage("Vehicle enter Successfully", 200);
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in Vehicle entery" + ex, 500);
            }

        }
    }
}
