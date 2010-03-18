using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using JobAds.Domain.Entities;
using System.Text.RegularExpressions;

namespace JobAds.Utils
{
    public static class RoutingUtils
    {
        public static RouteValueDictionary DetailsRouteValues(this JobAd jobAd)
        {
            return new RouteValueDictionary
            {
                { "controller", "Jobs" },
                { "action", "Details" },
                { "id", jobAd.JobAdId },
                { "country", MakeSimpleUrlSegment(jobAd.LocationCountry) },
                { "city", MakeSimpleUrlSegment(jobAd.LocationCity) },
                { "title", MakeSimpleUrlSegment(jobAd.Title) }
            };
        }

        private static string MakeSimpleUrlSegment(string value)
        {
            value = (value ?? string.Empty).Trim();
            value = value.Replace(" ", "-");
            return Regex.Replace(value, "[^0-9a-z\\-]", string.Empty, RegexOptions.IgnoreCase).ToLower();
        }
    }
}
