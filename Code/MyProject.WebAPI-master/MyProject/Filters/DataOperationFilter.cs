using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Filters
{
    public class DataOperationFilter : IActionFilter
    {
        int requireTransaction = 0;
        internal string sessionID = "";

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception == null)
            {
                if (filterContext.Result is JsonResult objectResult)
                {
                    if (!objectResult.StatusCode.HasValue || (objectResult.StatusCode.HasValue && objectResult.StatusCode.Value != StatusCodes.Status401Unauthorized))
                    {
                        try
                        {
                            var result = objectResult.Value;
                            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            };
                            var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(result.ToString());
                            var myJsonOutput = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);
                            var resultData = JObject.Parse(myJsonOutput.ToString());
                            if (resultData.ContainsKey("statusCode"))
                            {
                                //string value=JObject.Parse(resultData.)["statusCode"];
                                if (resultData["statusCode"].Value<int>() == 200)
                                {
                                    resultData.Add("HasErrors", false);
                                    filterContext.Result = new JsonResult(resultData);
                                }
                                else
                                {
                                    resultData.Add("HasErrors", true);
                                    filterContext.Result = new JsonResult(resultData);
                                }
                                
                                //resultData.Add("Data", resultData.);
                                
                            }
                            else
                            {
                                resultData.Add("HasErrors", false);
                                 resultData.Add("statusCode", 200);
                                filterContext.Result = new JsonResult(resultData);
                            }

                        }
                        catch (Exception ex)
                        {

                            throw;
                        }

                    }
                    ////filterContext.Result = Json(resultData);
                }
            }
            else
            {
                var errorResult = new JObject();
                errorResult.Add("HasErrors", true);

                errorResult.Add("Exception", Helper.GenerateExceptionLogMessage(filterContext.Exception));
                filterContext.ExceptionHandled = true;
                filterContext.Result = new JsonResult(errorResult);
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var transactionAttribute = context.ActionDescriptor.FilterDescriptors
                .Select(x => x.Filter).OfType<DataOperationAttribute>().FirstOrDefault();

            if (transactionAttribute != null && transactionAttribute.Transaction)
            {
                requireTransaction = 1;
            }
            else
            {
                requireTransaction = 0;
            }
            SetTransactionRequiredInContext();
        }

        private void SetTransactionRequiredInContext()
        {
            if (requireTransaction == 1)
            {
                //CoreRuntime.Context.AddToCache<string>(SessionKeys.RequireTransaction.ToString(), "1");
            }
            else
            {
                //CoreRuntime.Context.AddToCache<string>(SessionKeys.RequireTransaction.ToString(), "0");
            }
            //CoreRuntime.Context.AddToCache<string>(SessionKeys.TransactionInitialized.ToString(), "0");
            ////ServiceBase.SetupDBConnection();
        }
    }
}
