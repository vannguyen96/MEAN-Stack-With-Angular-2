using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //footer page
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        //header page
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        //Category page
        [ChildActionOnly]
        public ActionResult Category()
        {
            return PartialView();
        }

        //Category page
        [ChildActionOnly]
        public ActionResult TopProduct()
        {
            return PartialView();
        }
    }
}