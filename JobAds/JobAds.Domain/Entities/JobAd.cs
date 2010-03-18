using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.Mvc;

namespace JobAds.Domain.Entities
{
    public partial class JobAd
    {
        public int JobAdId { get; set; }
        public string Title { get; set; }
        public Decimal Salary { get; set; }
        public string Location { get; set; }
        public bool OnlyMembersMaySeeDetails { get; set; }
        
        public DateTime PublishFromDate { get; set; }

        public string MoreDetailsPDFFilename
        {
            get { return "c:\\examplePdfDocument.pdf"; } // Sufficient for now
        }

        public string LocationCountry // Maybe it would be better to store Country and City separately
        {
            get
            {
                if (Location == null)
                    return null;
                var lastComma = Location.LastIndexOf(',');
                return lastComma < 0 ? null : Location.Substring(lastComma + 1).Trim();
            }
        }

        public string LocationCity
        {
            get
            {
                if (Location == null)
                    return null;
                var lastComma = Location.LastIndexOf(',');
                return lastComma < 0 ? null : Location.Substring(0, lastComma).Trim();
            }
        }
    }
}
