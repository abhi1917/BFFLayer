using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Models
{
    public class LogModel
    {
        public DateTime TimeStamp { get; set; }
        public string Priority { get; set; }
        public string TransactionId { get; set; }
        public string Environment { get; set; }
        public string Host { get; set; }
        public string ApplicationIdentifier { get; set; }
        public string UserId { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string LogMessage { get; set; }
    }
    public enum Priority
    {
        ERROR,
        WARN,
        INFO,
        DEBUG,
        FATAL
    }
}