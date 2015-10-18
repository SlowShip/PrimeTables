using PrimeTables.Web.Models;
using PrimeTables.Web.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeTables.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
        [Route("", Name = RouteNames.Home.Index)]
        public ActionResult Index(int tableSize = 0)
        {
            // Todo remove
            var viewModel = new MultiplicationTableViewModel()
            {
                TableSize = tableSize,
                Table = new int[tableSize + 1, tableSize + 1] // +1 as first row and column are just the factors

            };

            return View(viewModel);
        }
    }
}