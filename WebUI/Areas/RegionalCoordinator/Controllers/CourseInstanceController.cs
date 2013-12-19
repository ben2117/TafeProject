using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using WebUI.Areas.RegionalCoordinator.Models;
using WebUI.Controllers;

namespace WebUI.Areas.RegionalCoordinator.Controllers
{
    public class CourseInstanceController : BaseController
    {
        //
        // GET: /RegionalCoordinator/CourseDescription/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCourseInstance()
        {
            var model = new CourseInstanceModel();
            model.Regions = _facade.FetchRegion();
            model.CourseDescriptions = _facade.FetchCourseDescription();
            model.CourseLeaders = Roles.GetUsersInRole("CourseLeader");
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCourseInstance(CourseInstanceModel model)
        {
            var query = _facade.FetchCourseInstanceByLeader(Membership.GetUser(User.Identity.Name).IsApproved, User.Identity.Name);
            if (query.Count() == 0)
            {
                _facade.createCourseInstance(model.RegionId, model.CourseDescriptionId, model.CourseCode, model.CourseLeader);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var q in query)
                {
                    if (model.CourseDescriptionId != q.Id)
                    {
                        _facade.createCourseInstance(model.RegionId, model.CourseDescriptionId, model.CourseCode, model.CourseLeader);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("CourseInstanceExists", "This course instance has been assigned.");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCourseInstance()
        {
            var model = new CourseInstanceModel();
            model.Regions = _facade.FetchRegion();
            model.CourseDescriptions = _facade.FetchCourseDescription();
            model.CourseLeaders = Roles.GetUsersInRole("CourseLeader");
            return View(model);
        }

        public ActionResult DisableCourseInstance()
        {
            var model = new CourseInstanceModel();
            model.Regions = _facade.FetchRegion();
            model.CourseDescriptions = _facade.FetchCourseDescription();
            model.CourseInstances = _facade.FetchCourseInstanceByLeader(Membership.GetUser(User.Identity.Name).IsApproved, User.Identity.Name);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult DisableCourseInstance(CourseInstanceModel model)
        {
            _facade.DisableCourseInstance(model.Id, model.RegionId);
            return View("Index");
        }



        

    }
}
