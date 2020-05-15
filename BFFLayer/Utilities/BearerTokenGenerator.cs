using BFFLayer.HttpHandlers;
using BFFLayer.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BFFLayer.Utilities
{
    public static class BearerTokenGenerator
    {
        public static async Task<string> GetAuthToken()
        {
            var basicToken = BasicTokenGenerator.GetBasicToken();
            Dictionary<string, string> headers = HttpUtility.GetTokenCallHeaders(basicToken);
            //Dictionary<string, string> body = new Dictionary<string, string>();
            //body.Add(ApiResource.GrantTypeKey, ApiResource.GrantTypeValue);
            HttpClient httpClient = new HttpClient(new HttpCallHandler(headers));
            var response = await httpClient.GetAsync(UrlResource.ApiBaseUrl + ApiResource.GetToken);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}