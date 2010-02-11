using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobAds.Domain.Entities;

namespace JobAds.Models
{
    public class SearchResultsViewModel
    {
        public string Query { get; set; }
        public IEnumerable<JobAd> Results { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchSuggestion { get; set; }
    }
}
