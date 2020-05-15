using BFFLayer.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Models
{
    public class Lead
    {
        [JsonProperty(JsonDefinition.LeadJsonDefinition.FirstName)]
        public string FirstName { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.LastName)]
        public string LastName { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.Address)]
        public string Address { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.AddressTwo)]
        public string AddressTwo { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.AddressThree)]
        public string AddressThree { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.HomePhone)]
        public string HomePhone { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.WorkPhone)]
        public string WorkPhone { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.Cell)]
        public string Cell { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.Ext)]
        public string Ext { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.Email)]
        public string Email { get; set; }
        [JsonProperty(JsonDefinition.LeadJsonDefinition.HonorsNumber)]
        public string HonorsNumber { get; set; }
    }
}