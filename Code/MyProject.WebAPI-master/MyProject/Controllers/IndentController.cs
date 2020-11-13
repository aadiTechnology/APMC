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
        public ActionResult<IndentDetails> Update([FromBody] IndentDetails indentDetails)
        {
            RepositoryWrapper.IndentDetails.Update(indentDetails);
            return null;
        }
    }
}
