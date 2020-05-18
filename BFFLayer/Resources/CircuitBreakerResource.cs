using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BFFLayer.Resources
{
    public static class CircuitBreakerResource
    {
        public static int RetryCount = 2;

        public static bool EnableCircuit = ConfigurationManager.AppSettings["EnableCircuit"].ToString()=="true";
    }
}