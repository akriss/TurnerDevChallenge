using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurnerDevChallenge.Models;

namespace TurnerDevChallenge.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string searchString)
        {
            ViewBag.Title = "Home Page";
            
            var model = new TitlesViewModel()
            {
                SearchString = searchString,
            };
            return View(model);
        }

        public ActionResult Details()
        {
            return PartialView("Details");
        }
    }
}
