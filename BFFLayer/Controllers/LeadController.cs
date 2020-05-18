using BFFLayer.Models;
using BFFLayer.Resources;
using BFFLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BFFLayer.Controllers
{
    public class LeadController : BaseController
    {
        [Route("api/Lead/{leadID}")]
        [HttpGet]
        public HttpResponseMessage Get(string leadID)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                AddResource(ApiResource.LeadDetails, HttpUtility.GetLeadCallHeaders(), null, TimeSpan.FromSeconds(ApiResource.TimeOutSeconds));
                var resp = Get().Result;
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    var body = resp.Content.ReadAsStringAsync().Result;
                    response.Content = new StringContent(ReturnResponse.LeadResponse(DataTranslator<BaseLead>.ResponseTranslator(body)), Encoding.UTF8, ApiResource.BodyTypeJson);
                    response.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    return resp;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ApiResource.ErrorMessage + Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault()+ex.Message, Encoding.UTF8, ApiResource.BodyTypeText);

            }
            return response;

        }
    }
}
