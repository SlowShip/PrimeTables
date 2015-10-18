using PrimeTables.Web.Plumbing;
using PrimeTables.Web.Services.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeTables.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ITestService testDependancy)
        {

        }

        [Route("", Name = RouteNames.Home.Index)]
        public ActionResult Index()
        {
            return View();
        }
    }
}