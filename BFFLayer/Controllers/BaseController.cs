using BFFLayer.HttpHandlers;
using BFFLayer.Resources;
using BFFLayer.Utilities;
using Polly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BFFLayer.Controllers
{
    [Logger]
    [RequestValidator]
    public class BaseController : ApiController
    {

        private Dictionary<string,string> _headers { get; set; }
        private Dictionary<string,string> _body { get; set; }
        private string _apiPath { get; set; }
        private TimeSpan _timeout { get; set; }

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                HttpClient client = new HttpClient(new HttpCallHandler(_headers, _body));
                client.Timeout = _timeout;
                return await client.GetAsync(UrlResource.ApiBaseUrl + _apiPath);
            }
            catch (Exception ex)
            {
                if(ex.InnerException.Message== ErrorMessages.TimeOutExceptionMessage)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.RequestTimeout,ApiResource.ErrorMessage+ Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault() + ErrorMessages.TimeOutErrorMessage);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ApiResource.ErrorMessage + Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault()+ex.Message);
            }
        }


        protected void AddResource(string apiPath,Dictionary<string, string> headers, Dictionary<string, string> body,TimeSpan timeout)
        {
            _headers = headers;
            _headers.Add(ApiResource.TransactionId, Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault());
            _headers.Add(ApiResource.AgentId, Request.Headers.GetValues(ApiResource.AgentId).FirstOrDefault());
            _body = body;
            _apiPath = apiPath;
            _timeout = timeout;
        }
    }
}
