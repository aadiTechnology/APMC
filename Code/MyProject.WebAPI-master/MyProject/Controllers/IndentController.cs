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
using MyProject.Repository;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Merchant,Driver,Admin,Agent,Transporter,Entry Gate Operator,Exit Gate Operator")]
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
        [HttpPost("AddIndent")]
        public async Task<JsonResult> AddIndent([FromBody] IndentDto IndentDto)
        {
            try
            {
                RepositoryWrapper.IndentDetails.AddIndent(IndentDto.IndentDetails, IndentDto.IndentProducts);
                return await base.FinalizStatusCodeeMessage("Indent Created Successfully", 200);
            }
            catch (Exception ex)
            {
                return await base.FinalizStatusCodeeMessage("Error: Failure in Indent Create : " + ex, 500);
            }

        }
        /// <summary>
        /// Author-Datta(Update Indent isApproved)
        /// </summary>
        /// <param name="indentDetails"></param>
        /// <returns>Successfully updated then return indent model</returns>




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
        [HttpGet("GenerateQrCode")]
        public async Task<JsonResult> GenerateQrCode(string indentId, string merchantId, string driverId)
        {
            return await base.FinalizeMultiple<byte[]>(RepositoryWrapper.IndentDetails.GenerateQRCode(indentId, merchantId, driverId));
        }

        [HttpGet("GetIndent")]
        public async Task<JsonResult> GetIndent(int indentId, int merchantId, string driverId)
        {
            return await base.FinalizeMultiple<IndentDetails>(RepositoryWrapper.IndentDetails.GetIndent(indentId,merchantId,driverId));
        }

        [HttpGet("GetIndentByDateRange")]
        public async Task<JsonResult> GetIndentByDateRange(DateTime fromDate,DateTime toDate)
        {
            return await base.FinalizeMultiple<List<IndentDetails>>(RepositoryWrapper.IndentDetails.GetIndentByDateRange(fromDate, toDate));
        }

        [HttpGet("UpdateScanned")]
        public async Task<JsonResult> UpdateIndent(int indentId, int merchantId, string driverId)
        {
            IndentDetails IndentDetails = RepositoryWrapper.IndentDetails.GetIndent(indentId, merchantId, driverId);
            if (IndentDetails != null)
            {
                if (IndentDetails.IsScanned)
                {
                    return await base.FinalizStatusCodeeMessage("Error:QR code is already scanned ", 500);
                }
                else
                {

                    return await base.FinalizeMultiple<IndentDetails>(RepositoryWrapper.IndentDetails.Update(IndentDetails));
                }
            }
            else
            {
                return await base.FinalizStatusCodeeMessage("Error: Indent is not found", 500);
            }
        }

        [HttpGet("GetIndentWithMerchantName")]
        public async Task<JsonResult> GetIndentWithMerchantName()
        {
            return await base.FinalizeMultiple<List<IndentMerchantDto>>(RepositoryWrapper.IndentDetails.GetIndentWithMerchantName());
        }



        [HttpPost("Update")]
        public async Task<JsonResult> UpdateIndent([FromBody] IndentDetails indentDetails)
        {
            return await base.FinalizeMultiple<IndentDetails>(RepositoryWrapper.IndentDetails.Update(indentDetails));
        }
        [HttpGet("GetIndentDetailsByMerchantID")]
        public async Task<JsonResult> GetIndentDetailsByMerchantID(int merchant)
        {
            return await base.FinalizeMultiple<List<IndentDetailsDto>>(RepositoryWrapper.IndentDetails.GetIndentDetailsByMerchantID(merchant));
        }
        [HttpGet("GetIndentDetailsByDriverID")]
        public async Task<JsonResult> GetIndentDetailsByDriverID(int driverId)
        {
            return await base.FinalizeMultiple<List<IndentDetailsDto>>(RepositoryWrapper.IndentDetails.GetIndentDetailsByDriverID(driverId));
        }
        [HttpGet("GetIndentDetails")]
        public async Task<JsonResult> GetIndentDetails(int indentId)
        {
            return await base.FinalizeMultiple<IndentDetailsDto>(RepositoryWrapper.IndentDetails.GetIndentDetails(indentId));
        }
        [HttpGet("GetIndent")]
        public async Task<JsonResult> GetIndent(int indentId, int merchantId, int driverId)
        {
            return await base.FinalizeMultiple<IndentDetailsDto>(RepositoryWrapper.IndentDetails.GetIndent(indentId, merchantId, driverId));
        }
        [HttpGet("GetIndent")]
        public async Task<JsonResult> GetIndent(int indentId)
        {
            return await base.FinalizeMultiple<IndentDetails>(RepositoryWrapper.IndentDetails.GetIndent(indentId));
        }
    }
}
