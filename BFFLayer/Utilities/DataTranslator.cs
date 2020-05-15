using BFFLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFFLayer.Utilities
{
    public static class DataTranslator<T>
    {
       

        public static T ResponseTranslator(string jsonToTranslate)
        {
            try
            {
                T responseObject = JsonConvert.DeserializeObject<T>(jsonToTranslate);
                return responseObject;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

 
        
    }
}