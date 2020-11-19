using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using MyProject.Repository;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //Author-Datta (Indent related methods)
    public class IndentController : ControllerBase
    {
        public override void InitializeController()
        {
        }
        public IndentController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }
        /// <summary>
        /// Author-Datta(Add Indent details and indent products)
        /// </summary>
        /// <param name="IndentDto"></param>
        /// <returns>Return Indent details if insert successfully</returns>
        [HttpPost("Add")]
        public async Task<JsonResult> Add([FromBody] IndentDto IndentDto)
        {
            try
            {
                return await base.FinalizeSingle<IndentDetails>(RepositoryWrapper.IndentDetails.Add(IndentDto.IndentDetails, IndentDto.IndentProducts));
                return await base.FinalizStatusCodeeMessage("Indent Created Successfully", 200);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Author-Datta(Update Indent isApproved)
        /// </summary>
        /// <param name="indentDetails"></param>
        /// <returns>Successfully updated then return indent model</returns>
        [HttpPost("Update")]
        public async Task<JsonResult> Update([FromBody] IndentDetails indentDetails)
        {
            RepositoryWrapper.IndentDetails.Update(indentDetails);
            return await base.FinalizStatusCodeeMessage("Updated Indent Successfully",200);
        }


        [HttpGet("GetOrderId")]
        public async Task<JsonResult> GetOrderId()
        {
            return await base.FinalizeMultiple<IEnumerable<IndentDetails>>(await RepositoryWrapper.IndentDetails.GetOrderId());
        }

        [HttpGet("GetProducts")]
        public async Task<JsonResult> GetProducts(int CategoryId)
        {
            return await base.FinalizeMultiple<IEnumerable<Product>>(await RepositoryWrapper.Product.GetProducts(CategoryId));
        }

        [HttpGet("GetUnits")]
        public async Task<JsonResult> GetUnits()
        {
            return await base.FinalizeMultiple<IEnumerable<Units>>(await RepositoryWrapper.Units.GetUnits());
        }

        [HttpGet("GetAllDrivers")]
        public async Task<JsonResult> GetAllDrivers()
        {
            return await base.FinalizeMultiple<IEnumerable<AppUsers>>(await RepositoryWrapper.AppUsers.GetAllDrivers());
        }
    }
}
