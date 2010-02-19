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
    }
}
