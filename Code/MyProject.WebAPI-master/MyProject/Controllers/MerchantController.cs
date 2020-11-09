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
    public class MerchantController : ControllerBase
    {
        public MerchantController(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        }
        public IRepositoryWrapper RepositoryWrapper { get; }

        [HttpGet("GetAllStallDetails")]
        public async Task<IEnumerable<StallDetails>> GetAllStallDetails()
        {
            return await RepositoryWrapper.StallDetails.GetAllStallDetails();
        }

        [HttpGet("GetAllProductCategory")]
        public async Task<IEnumerable<ProductCategory>> GetAllProductCategory()
        {
            return await RepositoryWrapper.ProductCategory.GetAllProductCategory();
        }
        [HttpPost("StallRegistration")]
        public ActionResult<StallRegistrationDto> StallRegistration([FromBody] StallRegistrationDto stallregisterDto)
        {
            try
            {
                RepositoryWrapper.StallRegistration.StallRegistration(stallregisterDto.UserId, stallregisterDto.StallId);
                RepositoryWrapper.StallProductCategories.StallProductCategories(stallregisterDto.Category.ToList(), stallregisterDto.StallId);

                return Content("Stall Registered Sucessfully");
            }
            catch (Exception ex)
            {
                return Content("Failure in Stall Registration : " + ex);
            }
        }
    }
}
