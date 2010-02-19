using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobAds.Domain.Entities;
using JobAds.Utils;

namespace JobAds.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Create()
        {
            var initialState = new JobAd
            {
                PublishFromDate = DateTime.Now.Date
            };
            return View(initialState);
        }

        [HttpPost]
        public ViewResult Create(JobAd jobAd, string referer)
        {
            ViewData["referer"] = referer;
            return View("BindingResults", jobAd);
        }
    }
}
