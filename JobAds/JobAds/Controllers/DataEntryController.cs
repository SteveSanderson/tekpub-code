using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using JobAds.Utils;

namespace JobAds.Controllers
{
    public class DataEntryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [iPhoneBrowser] [ActionName("Index")]
        public ActionResult Index_iPhone()
        {
            return Content("Maybe we should redirect you to the iPhone version...");
        }

        [HttpPost] [ActionName("Index")]
        public ActionResult Index_Post(string text)
        {
            return Content("You posted: " + HttpUtility.HtmlEncode(text));
        }

        [HttpPut] [ActionName("Index")]
        public ActionResult Index_Put(string text)
        {
            return Content("You put: " + HttpUtility.HtmlEncode(text));
        }
    }
}
