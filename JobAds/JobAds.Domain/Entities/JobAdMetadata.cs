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

            [Required(ErrorMessage="Please enter a title")]
            [StringLength(50, ErrorMessage="No more than 50 characters, please")]
            [ExcludeWords("monkey", "scapegoat")]
            public string Title { get; set; }

            [Required(ErrorMessage="Please enter the salary")]
            [Range(5000, int.MaxValue, ErrorMessage="Salary should be at least $5000")]
            public Decimal Salary { get; set; }

            [Required(ErrorMessage="Please enter the location")]
            public string Location { get; set; }

            [Option(Value=true, DisplayText="Members Only")]
            [Option(Value=false, DisplayText="Everyone")]
            public bool OnlyMembersMaySeeDetails { get; set; }

            [Required(ErrorMessage="When should this ad be published?")]
            public DateTime PublishFromDate { get; set; }
        }
    }
}
