using BFFLayer.HttpHandlers;
using BFFLayer.Resources;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BFFLayer.Utilities
{
    public static class HttpUtility
    {
        public static Dictionary<string,string> GetLeadCallHeaders()
        {
            string token = ApiResource.Bearer+StringResource.Space+BearerTokenGenerator.GetAuthToken().Result.Replace(StringResource.EscapedQuotes, StringResource.EmptyString);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(ApiResource.AuthorizationHeader, token);
            headers.Add(ApiResource.AcceptHeader, ApiResource.JsonHeaderType);
            return headers;
        }



        public static Dictionary<string,string> GetTokenCallHeaders(string token)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add(ApiResource.AuthorizationHeader, token);
            //headers.Add(ApiResource.ContentTypeHeader,ApiResource.FormUrlEncodedHeader);
            return headers;
        }
        

    }
}