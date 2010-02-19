using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using System.Globalization;

namespace JobAds.Utils
{
    public class HttpHeadersValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new NameValueCollectionValueProvider(controllerContext.HttpContext.Request.Headers, CultureInfo.InvariantCulture);
        }
    }
}
