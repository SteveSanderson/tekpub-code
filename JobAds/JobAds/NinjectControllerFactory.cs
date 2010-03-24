using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JobAds.Domain.Abstractions;
using JobAds.Domain.Repositories;
using JobAds.Domain.Services;
using JobAds.Controllers;
using Ninject;
using Ninject.Modules;

namespace JobAds
{
    internal class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel = new StandardKernel(new JobAdsDependencies());

        protected override IController GetControllerInstance(RequestContext requestContext, 
                                                             Type controllerType)
        {
            return controllerType != null ? (IController)kernel.Get(controllerType)
                                          : null;
        }

        private class JobAdsDependencies : NinjectModule
        {
            public override void Load()
            {
                Bind<IJobAdRepository>().To<DbJobAdRepository>();
                Bind<ISearchSuggestor>().To<GoogleSearchSuggestor>();
            }
        }
    }
}
