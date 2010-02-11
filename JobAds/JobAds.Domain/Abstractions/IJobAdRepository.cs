using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobAds.Domain.Entities;

namespace JobAds.Domain.Abstractions
{
    public interface IJobAdRepository
    {
        IQueryable<JobAd> JobAds { get; }
        IEnumerable<JobAd> Search(string query);
    }
}
