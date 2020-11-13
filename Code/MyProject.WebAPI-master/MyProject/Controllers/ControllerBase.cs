using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        internal string requestorIP = "";
        public JObject ResponseData { get; set; }

        public ControllerBase() : base()
        {
            ResponseData = new JObject();
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            InitializeController();
        }

        public abstract void InitializeController();


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public async Task<JsonResult> FinalizeEmpty()
        {
            ResponseData = JObject.FromObject(new JObject());
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }

        public async Task<JsonResult> FinalizeSingle<T>(T data)
        {
            ResponseData = JObject.FromObject(data);
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }
        //public JsonResult FinalizeSingle1<T>(T data)
        //{
        //    ResponseData = JObject.FromObject(data);
        //    return  new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)).js;
        //}

        public async Task<JsonResult> FinalizeMultiple<T>(T data)
        {
            try
            {
                if (ResponseData == null)
                {
                    ResponseData = new JObject();
                }
                ResponseData.Add("Rows", JArray.FromObject(data));
                return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<JsonResult> FinalizeMessage(string message)
        {
            ResponseData = new JObject();
            ResponseData.Add("Message", message);
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }
        public async Task<JsonResult> FinalizStatusCodeeMessage(string message,int statusCode)
        {
            ResponseData = new JObject();
            ResponseData.Add("Message", message);
            ResponseData.Add("StatusCode", statusCode);
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }

        public async Task<JsonResult> FinalizeJObject(JObject data)
        {
            ResponseData = data;
            if (ResponseData == null)
            {
                ResponseData = new JObject();
            }
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }

        public async Task<JsonResult> FinalizeJArray(JArray data)
        {
            if (ResponseData == null)
            {
                ResponseData = new JObject();
            }
            ResponseData.Add("Rows", data);
            return await Task<JsonResult>.Run(new Func<JsonResult>(() => PrepareResponseMessage(ResponseData)));
        }

        public JsonResult PrepareResponseMessage(JObject data)
        {
            return Json(data);
        }

    }
}
