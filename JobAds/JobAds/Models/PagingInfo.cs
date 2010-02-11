using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAds.Models
{
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int TotalResults { get; set; }
        public int PageSize { get; set; }

        public int PageCount
        {
            get { return Math.Max(1, (int)Math.Ceiling((double)TotalResults / PageSize)); }
        }

        public int FirstResultIndex
        {
            get { return TotalResults == 0 ? 0 : 1 + PageSize*(CurrentPage-1); }
        }

        public int LastResultIndex
        {
            get { return Math.Min(TotalResults, PageSize * CurrentPage); }
        }
    }
}
