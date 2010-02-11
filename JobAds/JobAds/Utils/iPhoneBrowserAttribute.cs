using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace JobAds.Utils
{
    public class iPhoneBrowserAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, 
                                               MethodInfo methodInfo)
        {
            string userAgent = controllerContext.HttpContext.Request.UserAgent;
            return userAgent.Contains("iPhone");
        }
    }
}
