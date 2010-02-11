using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobAds.Domain.Entities
{
    public class JobAd
    {
        public int JobAdId { get; internal set; }
        public string Title { get; set; }
        public Decimal Salary { get; set; }
        public string Location { get; set; }
        public bool OnlyMembersMaySeeDetails { get; set; }

        public string MoreDetailsPDFFilename
        {
            get { return "c:\\examplePdfDocument.pdf"; } // Sufficient for demo
        }
    }
}
