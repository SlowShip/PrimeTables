using PrimeTables.Web.ModelProviders.Number;
using PrimeTables.Web.Models;
using PrimeTables.Web.Plumbing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeTables.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMultiplicationTableViewModelFactory viewModelFactory;

        public HomeController(IMultiplicationTableViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        [HttpGet]
        [Route("", Name = RouteNames.Home.Index)]
        public ActionResult Index(TableRequestBindingModel model = null)
        {
            if (model == null || model.TableSize == 0)
            {
                return View(new MultiplicationTableViewModel());
            }

            if (!ModelState.IsValid)
            {
                return View(new MultiplicationTableViewModel()
                {
                    TableSize = model.TableSize
                });
            }

            var viewModel = viewModelFactory.Create(SequenceType.Primes, model.TableSize);
            return View(viewModel);
        }
    }
}