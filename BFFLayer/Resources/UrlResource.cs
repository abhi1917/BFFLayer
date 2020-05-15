using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BFFLayer.Resources
{
    public static class UrlResource
    {
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
    }
}