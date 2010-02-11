using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using JobAds.Domain.Abstractions;
using JobAds.Domain.Repositories;
using System.ComponentModel;
using JobAds.Models;
using System.Xml.Linq;
using JobAds.Utils;
using JobAds.Domain.Entities;
using JobAds.ActionResults;
using JobAds.Domain.Services;

namespace JobAds.Controllers
{
    public class JobsController : AsyncController
    {
        private IJobAdRepository jobAdRepository;
        private ISearchSuggestor searchSuggestor;
        private const int PageSize = 8;

        public JobsController(IJobAdRepository repository, ISearchSuggestor suggestor) 
        {
            jobAdRepository = repository;
            searchSuggestor = suggestor;
        }

        public ViewResult Index()
        {
            return View();
        }

        public void SearchAsync(string query, [DefaultValue(1)] int page)
        {
            // Asynchronously query the search suggestions service
            AsyncManager.OutstandingOperations.Increment();
            searchSuggestor.BeginGetSuggestion(query, asyncResult => {
                // Now collect the final result
                string suggestion = searchSuggestor.EndGetSuggestion(asyncResult);
                AsyncManager.Parameters["searchSuggestion"] = suggestion;

                // Allow the request to complete
                AsyncManager.OutstandingOperations.Decrement();
            });

            // Run the query and construct the view model
            var results = jobAdRepository.Search(query);
            var viewModel = new SearchResultsViewModel
            {
                Query = query,
                Results = results.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    TotalResults = results.Count(),
                    PageSize = PageSize
                }
            };

            AsyncManager.Parameters["viewModel"] = viewModel;
        }

        public ActionResult SearchCompleted(SearchResultsViewModel viewModel, string searchSuggestion)
        {
            int page = viewModel.PagingInfo.CurrentPage;
            if (page < 1 || page > viewModel.PagingInfo.PageCount)
            {
                // Force the user back to a valid page index
                TempData["message"] = "Sorry - there is no page " + page + "!";
                return RedirectToAction("Search", new { viewModel.Query, page = 1 });
            }

            viewModel.SearchSuggestion = searchSuggestion;
            return View(viewModel);
        }

        public ContentResult Feed(string query)
        {
            XDocument rss = RssUtils.GetRssXml(
                string.Format("Jobs matching '{0}'", query), // Feed title
                jobAdRepository.Search(query)                // Job ads
            );

            return Content(rss.ToString(), "application/rss+xml");
        }

        public ActionResult DownloadJobDetails(int jobAdId)
        {
            JobAd ad = jobAdRepository.JobAds.First(x => x.JobAdId == jobAdId);

            if (ad.OnlyMembersMaySeeDetails && !Request.IsAuthenticated)
                return new HttpUnauthorizedResult();

            return File(ad.MoreDetailsPDFFilename, // Actual filename on server
                        "application/pdf",         // MIME type
                        "FullDetails.pdf");        // Suggest filename to browser
        }

        public CsvResult<JobAd> Export(string query)
        {
            var results = jobAdRepository.Search(query);

            return new CsvResult<JobAd>(results, 
                x => x.Title,    
                x => x.Location,
                x => x.Salary.ToString("c")
            );
        }
    }
}