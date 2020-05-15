using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Resources
{
    public static class ApiResource
    {
        public static string LeadDetails = "/MockLead";
        public static string GetToken = "/TokenUrl";
        public static int TimeOutSeconds = 2;
        public static string BodyTypeJson = "application/json";
        public static string BodyTypeText = "application/text";
        public static string GrantTypeKey = "grant_type";
        public static string GrantTypeValue = "client_credentials";
        public static string Bearer = "Bearer";
        public static string Basic = "Basic";
        public static string AuthorizationHeader = "Authorization";
        public static string AcceptHeader = "Accept";
        public static string JsonHeaderType = "application/json";
        public static string ContentTypeHeader = "Content-Type";
        public static string FormUrlEncodedHeader = "application/x-www-form-urlencoded";
        public static string TransactionId = "transactionID";
        public static string AgentId = "agentID";
        public static string TransactionIdMissingMessage = "TransactionID or AgentID missing in the request!";
        public static string ErrorMessage = "For TransactionId: ";
    }
}