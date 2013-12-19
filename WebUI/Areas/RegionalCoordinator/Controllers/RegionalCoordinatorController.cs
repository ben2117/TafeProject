using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Controllers;
using System.Web.Security;
using WebMatrix.WebData;
namespace WebUI.Areas.RegionalCoordinator.Controllers
{
    public class RegionalCoordinatorController : BaseController 
    {
        //
        // GET: /RegionalCoordinator/RegionalCoordinator/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
