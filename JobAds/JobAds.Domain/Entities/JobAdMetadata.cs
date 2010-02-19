using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using JobAds.Domain.Metadata;

namespace JobAds.Domain.Entities
{
    [MetadataType(typeof(JobAdMetadata))]
    public partial class JobAd
    {
        // Not used except as a source of metadata
        class JobAdMetadata
        {
            public int JobAdId { get; internal set; }

            public string Title { get; set; }

            public Decimal Salary { get; set; }
            public string Location { get; set; }

            [Option(Value=true, DisplayText="Members Only")]
            [Option(Value=false, DisplayText="Everyone")]
            public bool OnlyMembersMaySeeDetails { get; set; }

            public DateTime PublishFromDate { get; set; }
        }
    }
}
