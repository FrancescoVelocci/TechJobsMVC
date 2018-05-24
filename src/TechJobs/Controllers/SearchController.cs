using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;


namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ListController lc = new ListController();

            if (searchType.Equals("all") && !String.IsNullOrEmpty(searchTerm))
            {
                return lc.AllJobs(searchTerm);
            }

            if (String.IsNullOrEmpty(searchTerm))
            {
                return lc.AllJobs("");
            }

            else
            {
                return lc.Jobs(searchType, searchTerm, true);
            }
        }
    }
}
