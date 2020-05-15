using BFFLayer.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BFFLayer.Utilities
{
    public class RequestValidator : ActionFilterAttribute
    {
        /// <summary>
        /// Filter implementation to validate input data
        /// </summary>
        /// <param name="actionContext">http action context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Headers.Contains(ApiResource.TransactionId)|| !actionContext.Request.Headers.Contains(ApiResource.AgentId))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ApiResource.TransactionIdMissingMessage);
                return;
            }
            base.OnActionExecuting(actionContext);
        }
    }
}