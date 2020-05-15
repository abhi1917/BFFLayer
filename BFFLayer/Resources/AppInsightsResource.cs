using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BFFLayer.Resources
{
    public static class AppInsightsResource
    {
        public static string Key= ConfigurationManager.AppSettings["InstrumentationKey"].ToString();
        public static string Message = "Tracking event from customer web api request";
    }
}