using BFFLayer.Resources;
using log4net;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BFFLayer.Utilities
{
    public class Logger:ActionFilterAttribute
    {
        private static TelemetryClient tc = new TelemetryClient();
        private static ILog _logger = LogManager.GetLogger(LoggerResource.LoggerName);
        private DateTime _start;
        /// <summary>
        /// Filter to log before an action starts
        /// </summary>
        /// <param name="actionContext">current http context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _start = DateTime.Now;
            _logger.Info(LoggerResource.TransactionID+actionContext.Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault() + LoggerResource.Method + actionContext.Request.Method + LoggerResource.Url+ actionContext.Request.RequestUri + LoggerResource.TimeStart+ DateTime.Now);
            base.OnActionExecuting(actionContext);
        }
        /// <summary>
        /// filter to log after an action ends
        /// </summary>
        /// <param name="actionExecutedContext">current http context</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            tc.InstrumentationKey = AppInsightsResource.Key;
            tc.Context.User.Id = Environment.UserName;
            tc.Context.Session.Id = Guid.NewGuid().ToString();
            tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            tc.TrackEvent(AppInsightsResource.Message);
            if (null != actionExecutedContext.Response && actionExecutedContext.Response.StatusCode != HttpStatusCode.InternalServerError)
            {
                tc.TrackRequest(actionExecutedContext.Request.RequestUri.AbsoluteUri, _start, DateTime.Now - _start, actionExecutedContext.Response.StatusCode.ToString(), true);

            }
            else
            {
                tc.TrackRequest(actionExecutedContext.Request.RequestUri.AbsoluteUri, _start, DateTime.Now - _start, HttpStatusCode.InternalServerError.ToString(), false);
            }
            tc.Flush();
            _logger.Info(LoggerResource.TransactionID + actionExecutedContext.Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault() + LoggerResource.Method + actionExecutedContext.Request.Method + LoggerResource.Url + actionExecutedContext.Request.RequestUri + LoggerResource.TimeEnded + DateTime.Now);
            base.OnActionExecuted(actionExecutedContext);
        }

    }
}