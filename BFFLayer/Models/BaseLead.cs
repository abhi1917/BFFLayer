using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Models
{
    public class BaseLead
    {
        public LeadArraySuccessResponse LeadArraySuccessResponse { get; set; }
    }

    public class LeadArraySuccessResponse
    {
        public Lead[] Lead { get; set; }
    }
}