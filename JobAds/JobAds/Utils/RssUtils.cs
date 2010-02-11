using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobAds.Domain.Entities;
using System.Text;
using System.Xml.Linq;

namespace JobAds.Utils
{
    public static class RssUtils
    {
        public static XDocument GetRssXml(string title, IEnumerable<JobAd> jobAds)
        {
            return new XDocument(new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                new XElement("rss", new XAttribute("version", "2.0"),
                    new XElement("channel", new XElement("title", title),
                        from jobAd in jobAds
                        select new XElement("item",
                              new XElement("title", jobAd.Title),
                              new XElement("guid", new XAttribute("isPermaLink", "false"), "http://example.com/" + jobAd.JobAdId),
                              new XElement("description", string.Format("{0:$0,000}, {1}", jobAd.Salary, jobAd.Location))
                        )
                    )
                )
            );
        }
    }
}
