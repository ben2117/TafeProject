using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using WebUI.Areas.CourseLeader.Models;
using WebUI.Controllers;

namespace WebUI.Areas.CourseLeader.Controllers
{
    public class ManageSessionsController : BaseController
    {

        public ActionResult Index(Guid courseInstanceId, Guid regionId, Guid classId)
        {
            var model = new ManageSession();
            model.courseInstanceId = courseInstanceId;
            model.regionId = regionId;
            model.classGroupId = classId;
            model.Sessions = _facade.FetchSession(regionId, courseInstanceId, classId).OrderBy(d => d.Date);
            var classGroup = _facade.FetchClassGroup(regionId, courseInstanceId, classId);
            
            model.classGroup = classGroup.ClassGroupName;
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateNewSession(Guid classGroupId, Guid courseInstanceId, Guid regionId)
        {
            var model = new CreateSession();
            model.classGroupId = classGroupId;
            model.courseInstanceId = courseInstanceId;
            model.regionId = regionId;
            model.courseInstances = _facade.FetchCourseInstanceByLeader(Membership.GetUser(User.Identity.Name).IsApproved, User.Identity.Name);
            model.areaId = _facade.FetchClassGroup(regionId, courseInstanceId, classGroupId).DefaultAreaId;
            model.hour = "HH";
            model.minute="MM";
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateNewSession(Guid regionId, Guid courseInstanceId, Guid classGroupId, string startDate, int numberOfSessions, Frequency freq, Guid areaId)
        {
            System.Globalization.CultureInfo cultureinfo =  new System.Globalization.CultureInfo("en-AU");
            DateTime theDate = DateTime.Parse(startDate, cultureinfo);
            
            var session = _facade.CreateSesssions(regionId, courseInstanceId, classGroupId, theDate, numberOfSessions, freq);
            return Content("");
        }

        public ActionResult toIndex()
        {
            return RedirectToAction("Index", "CourseLeader");
        }


        #region ajaxCalls

        [HttpPost]
        public ActionResult SelectClassGroup(Guid courseInstanceId, Guid regionId)
        {
            //var courseInstance = _facade.FetchCourseInstanceByLeader(Membership.GetUser(User.Identity.Name).IsApproved, User.Identity.Name);
            var classGroups = _facade.FetchClassGroup(regionId, courseInstanceId);

            var theHtml = "";
            theHtml += "<option></option>";

            if (classGroups.Count() == 0)
            {
                theHtml += "<option value=" + "none" + "disabled>No Class Groups exist for this course instance</option>";
                return Content(theHtml);
            }
            else
            {
                foreach (var r in classGroups)
                {
                    theHtml += "<option value=\"" + r.Id + "\">" + r.ClassGroupName + "</option>";


                }
                return Content(theHtml);
            }

        }




        #endregion
    }
}
