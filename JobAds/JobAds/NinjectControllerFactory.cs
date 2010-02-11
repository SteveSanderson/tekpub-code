using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Core;
using JobAds.Domain.Abstractions;
using JobAds.Domain.Repositories;
using JobAds.Domain.Services;
using JobAds.Controllers;
using Ninject.Core.Behavior;

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

        private class JobAdsDependencies : StandardModule
        {
            public override void Load()
            {
                //Bind<JobsController>().To<JobsController>().Using<SingletonBehavior>();
                Bind<IJobAdRepository>().To<DbJobAdRepository>();
                Bind<ISearchSuggestor>().To<GoogleSearchSuggestor>();
            }
        }
    }
}
