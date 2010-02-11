using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobAds.Domain.Abstractions;
using JobAds.Domain.Entities;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Configuration;

namespace JobAds.Domain.Repositories
{
    public class DbJobAdRepository : IJobAdRepository
    {
        private Table<JobAd> jobAdsTable;

        public DbJobAdRepository()
        {
            var mappings = XmlMappingSource.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("JobAds.Domain.Repositories.LinqToSqlMappings.xml"));
            var dataContext = new DataContext(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString, mappings);
            jobAdsTable = dataContext.GetTable<JobAd>();
        }

        public IQueryable<JobAd> JobAds
        {
            get { return jobAdsTable; }
        }

        public IEnumerable<JobAd> Search(string query)
        {
            // Incredibly simplistic matching on multiple keywords
            var results = JobAds;
            foreach (string keyword in query.Split(' '))
            {
                string currentKeyword = keyword; // Need the closure to capture a separate variable on each iteration - see http://blogs.msdn.com/ericlippert/archive/2009/11/12/closing-over-the-loop-variable-considered-harmful.aspx
                results = results.Where(x => x.Title.Contains(currentKeyword) || x.Location.Contains(currentKeyword));
            }
            return results;
        }
    }
}
