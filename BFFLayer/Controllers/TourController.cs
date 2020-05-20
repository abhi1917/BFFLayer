using BFFLayer.Resources;
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
    public class TourController : BaseController
    {
        [Route("api/Availability")]
        [HttpGet]
        public HttpResponseMessage GetTour(string fromDate,string toDate,string officeIdList)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                AddResource(ConfigurationManager.AppSettings["tourUrl"].ToString(), new Dictionary<string, string>(), null, TimeSpan.FromSeconds(ApiResource.TimeOutSeconds));
                return Get();
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ApiResource.ErrorMessage + Request.Headers.GetValues(ApiResource.TransactionId).FirstOrDefault() + ex.Message, Encoding.UTF8, ApiResource.BodyTypeText);

            }
            return response;

        }
    }
}
