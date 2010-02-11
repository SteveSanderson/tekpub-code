using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JobAds.Controllers;
using JobAds.Domain.Abstractions;
using JobAds.Domain.Entities;
using System.Web.Mvc;
using JobAds.Models;

namespace JobAds.Test
{
    /*
    [TestFixture]
    public class Searching
    {
        [Test]
        public void WhenUserRequestsPageSix_DisplaysPageSixOfResults()
        {
            // Arrange
            var controller = new JobsController(new TestJobAdRepository(100));

            // Act
            var result = (ViewResult)controller.Search("testQuery", 6);

            // Assert: Page 6 displays Job51 up to Job60
            var model = (SearchResultsViewModel)result.ViewData.Model;
            Assert.That(model.PagingInfo.CurrentPage, Is.EqualTo(6));
            var jobAds = model.Results.ToList();
            for (var i = 0; i < 8; i++)
                Assert.That(jobAds[i].Title, Is.EqualTo("Job" + (i + 41)));
        }

        [Test]
        public void WhenUserRequestsInvalidPageIndex_RedirectsToPageOne()
        {
            // Arrange
            var controller = new JobsController(new TestJobAdRepository(16));

            // Act
            var result = (RedirectToRouteResult)controller.Search("testQuery", 3);

            // Assert
            Assert.That(result.RouteValues["action"], Is.EqualTo("Search"));
            Assert.That(result.RouteValues["query"],  Is.EqualTo("testQuery"));
            Assert.That(result.RouteValues["page"],   Is.EqualTo(1));
        }

        private class TestJobAdRepository : IJobAdRepository {
            private List<JobAd> _jobAds;

            public TestJobAdRepository(int numItems)
            {
                _jobAds = new List<JobAd>();
                for (int i = 1; i <= numItems; i++)
                    _jobAds.Add(new JobAd { Title = "Job" + i });
            }

            public IQueryable<JobAd> JobAds
            {
                get { return _jobAds.AsQueryable(); }
            }

            public IEnumerable<JobAd> Search(string query)
            {
                return JobAds;
            }
        }
    }
     * */
}
