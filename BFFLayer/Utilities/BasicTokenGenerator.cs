using BFFLayer.Resources;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BFFLayer.Utilities
{
    public static class BasicTokenGenerator
    {
        public static string GetBasicToken()
        {
            var clientCredentials = GetClientSecret();
            string result = clientCredentials.Result;
            return ApiResource.Basic+StringResource.Space+Base64Encode(result);
        }

        public static async Task<string> GetClientSecret()
        {
            //AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            //KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            //var secret = await keyVaultClient.GetSecretAsync(KeyVaultResource.KeyVaultUrl + KeyVaultResource.Secrets + KeyVaultResource.ClientId)
            //        .ConfigureAwait(false);
            return KeyVaultResource.ClientId + StringResource.SemiColon + "password123";
        }

        public static string Base64Encode(string text)
        {
            var returnVal = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(returnVal);
        }
    }
}