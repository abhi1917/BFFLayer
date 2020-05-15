using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BFFLayer.Resources
{
    public static class KeyVaultResource
    {
        public static string KeyVaultUrl= ConfigurationManager.AppSettings["keyVaultUrl"].ToString();
        public static string ClientId= ConfigurationManager.AppSettings["clientId"].ToString();
        public static string Secrets = "secrets/";
    }
}