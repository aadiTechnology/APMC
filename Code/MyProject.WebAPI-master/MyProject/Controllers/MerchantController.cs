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
   [Authorize(Roles = "Merchant")]
    public class MerchantController : ControllerBase
    {
        public override void InitializeController()
        {

        }

        public MerchantController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }

        /// <summary>
        /// GetAllStallDetails - Dosent need any Parameter to pass returns the list of StallDetails from master where stall is not Assigned
        /// </summary>
        /// <param> </param>
        /// <returns>Returns the list of StallDetails from master where stall is not Assigned</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
        [HttpGet("GetAllStallDetails")]
        public async Task<JsonResult> GetAllStallDetails()
        {
            return await base.FinalizeMultiple < IEnumerable <StallDetails>> (await RepositoryWrapper.StallDetails.GetAllStallDetails());
        }

   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
        [HttpGet("GetAllProductCategory")]
        public async Task<JsonResult> GetAllProductCategory()
        {
            return await base.FinalizeMultiple<IEnumerable<ProductCategory>>(await RepositoryWrapper.ProductCategory.GetAllProductCategory());
        }


        /// <summary>
        /// StallRegistration - Merchant Stall registeration details from Form are resived hear and inserted in to stall registeration table
        /// StallProductCategories- the Product category of stall is resived from form and inserted in StallProductCategories table
        /// </summary>
        /// <param>
        /// Input type Json
        /// {"UserId":2,"StallId":3,"IsApproved":false,"IsRejected":false,"Category":[3,2] }
        /// </param>
        /// <returns>Returns status/Exception if Sucessfully Registered data in table or not</returns>
        ///<Aurthor>Sumeet Tanaji Kemse</Aurthor>
    [HttpPost("StallRegistration")]
        public async Task<JsonResult> StallRegistration([FromBody] StallRegistrationDto stallregisterDto)
        {
            try
            {
                RepositoryWrapper.StallRegistration.StallRegistration(stallregisterDto.UserId, stallregisterDto.StallId);


                if (stallregisterDto.Category.ToList().Count==0)
                {
                    return await base.FinalizStatusCodeeMessage("Error: Category Is Not Selected Or Empty", 500);
                }
                
                RepositoryWrapper.StallProductCategories.StallProductCategories(stallregisterDto.Category.ToList(), stallregisterDto.StallId);

                return await base.FinalizStatusCodeeMessage("Stall Registered Sucessfully",200);
                
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in Stall Registration : " + ex,500);
            }
        }
    }
}
