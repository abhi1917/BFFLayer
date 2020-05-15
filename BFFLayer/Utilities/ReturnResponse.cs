using BFFLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Utilities
{
    public static class ReturnResponse
    {
        public static string LeadResponse(BaseLead lead)
        {
            return JsonConvert.SerializeObject(lead.LeadArraySuccessResponse.Lead);
        }
    }
}