using BFFLayer.Models;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Environment = NHibernate.Validator.Cfg.Environment;

namespace BFFLayer.Utilities
{
    public class LeadRequestValidator : ActionFilterAttribute
    {
        private ValidatorEngine _ve = new ValidatorEngine();
        /// <summary>
        /// Filter implementation to validate input data
        /// </summary>
        /// <param name="actionContext">http action context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            InputLead input = new InputLead();
            input.LeadID = (string)actionContext.ActionArguments["leadID"];
            ConfigureValidator();
            if (!_ve.IsValid(input))
            {
                var results = _ve.Validate(input);
                string errors = "";
                foreach (InvalidValue error in results)
                {
                    errors += error.Message + ". ";
                }
                actionContext.Response = actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, errors);
                return;
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// Configure nhibernate validator
        /// </summary>
        private void ConfigureValidator()
        {
            INHVConfiguration nhvc = new XmlConfiguration();
            nhvc.Properties[Environment.ApplyToDDL] = "true";
            nhvc.Properties[Environment.AutoregisterListeners] = "true";
            nhvc.Properties[Environment.ValidatorMode] = ValidatorMode.UseExternal.ToString();
            nhvc.Mappings.Add(new MappingConfiguration("BFFLayer", null));
            _ve.Configure(nhvc);
        }
    }
}