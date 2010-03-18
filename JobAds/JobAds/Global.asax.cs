using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JobAds.Utils;

namespace JobAds
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "jobs/{country}/{city}/{title}/{id}",
                new { controller = "Jobs", action = "Details" },
                new { id = @"\d+" }
            );

            routes.MapRoute(
                "Default",                          // Route name
                "{controller}/{action}/{id}",       // URL with parameters
                new { controller = "Jobs",          // Parameter defaults
                      action = "Index", 
                      id = UrlParameter.Optional }  
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelMetadataProviders.Current = new JobAdsMetadataProvider();
            ValueProviderFactories.Factories.Add(new HttpHeadersValueProviderFactory());
            ModelBinders.Binders.Add(typeof(DateTime), new NaturalDatesModelBinder());
            ModelValidatorProviders.Providers.Add(new JobAdsValidationProvider());
        }
    }
}