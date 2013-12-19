using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using WebUI.Areas.CourseLeader.Models;
using WebUI.Controllers;


namespace WebUI.Areas.CourseLeader.Controllers
{
    public class CourseLeaderController : BaseController
    {
        //
        // GET: /CourseLeader/CourseLeader/

        #region courseLeader

        public ActionResult Index()
        {
            var model = new CourseLeader.Models.CourseLeader();
            model.Name = User.Identity.Name;
            model.Courses = _facade.FetchCourseInstanceByLeader(Membership.GetUser(model.Name).IsApproved, model.Name);
            model.CourseDescription = _facade.FetchCoursesDescriptionForLeader(Membership.GetUser(model.Name).IsApproved, model.Name);
            
            return View(model);
        }


        #endregion



        //Options for each course
        public ActionResult CourseOptions(Guid instanceId, Guid regionId)
        {
            var vModel = new CourseOptions();
            vModel.RegionId = regionId;
            vModel.CourseInstanceId = instanceId;
            vModel.ClassGroups = _facade.FetchClassGroup(vModel.RegionId, vModel.CourseInstanceId).OrderBy(c => c.ClassGroupName);
            //
            vModel.CourseDescriptions = _facade.FetchCoursesDescriptionForLeader(Membership.GetUser(User.Identity.Name).IsApproved, User.Identity.Name);
            return View(vModel);
        }

        #region Class Group
        [HttpGet]
        public ActionResult CreateClassGroup(Guid instanceId, Guid regionId)
        {
            var model = new ClassGroup();
            //model.Areas
            model.CourseInstanceId = instanceId;
            model.RegionId = regionId;
            model.Suburbs = _facade.FetchSuburb(regionId);

            return View(model);
        }



        [HttpPost]
        public ActionResult CreateClassGroup(Guid Rid, Guid Aid, Guid Cid, int count, string name)
        {
            _facade.CreateClassGroup(Rid, Cid, count, name, Aid);
            var no = "";
            return Content(no);
        }
        #endregion

        #region Attendance
        public ActionResult MarkAttendance(Guid regionId, Guid courseInstanceId, Guid classGroupId, Guid sessionId)
        {
            var model = new Attendance();
            model.regionId = regionId;
            model.courseInstanceId = courseInstanceId;
            model.classGroupId = classGroupId;
            model.sessionId = sessionId;
            model.attendances = _facade.FetchAttendance(regionId, courseInstanceId, classGroupId, sessionId);
            return View(model);

        }

        [HttpPost]
        public ActionResult MarkAttendance(Guid regionId, Guid courseInstanceId, Guid classGroupId, Guid sessionId, int memberId, String state)
        {
            var model = new Attendance();
            if (ModelState.IsValid)
            {       
                model.regionId = regionId;
                model.courseInstanceId = courseInstanceId;
                model.classGroupId = classGroupId;
                model.sessionId = sessionId;
                _facade.MarkAttendance(regionId, courseInstanceId, classGroupId, sessionId, memberId, state.ElementAt(0));
                return RedirectToAction("MarkAttendance", model);
            }

            return View(model);
        }

        public ActionResult MarkAttendanceToday(Guid regionId, Guid courseInstanceId, Guid classGroupId)
        {
            var model = new Attendance();
            var today = DateTime.Now;
            var sessions = _facade.FetchSession(regionId, courseInstanceId, classGroupId);
            ISession todaysSession = null;
            foreach (var s in sessions)
            {
                if (s.Date.DayOfYear.Equals(today.DayOfYear))
                {
                    todaysSession = s;
                }
            }
            if (todaysSession != null)
            {
                model.regionId = regionId;
                model.courseInstanceId = courseInstanceId;
                model.classGroupId = classGroupId;
                model.sessionId = todaysSession.Id;
                return RedirectToAction("MarkAttendance", model);
            }
            else { return RedirectToAction("Index", model); };
        }

        public ActionResult ViewAttendance(Guid regionId, Guid courseInstanceId, Guid classGroupId)
        {
            var sessions = _facade.FetchSession(regionId, courseInstanceId, classGroupId);
            //var days = new List<
            //foreach (var s in sessions)
            //{

            //    var x = s.Attendances;
            //    var y = 8;
            //}
            var model = new ViewAttendance();
            model.Sessions = sessions.OrderBy(d => d.Date).ToList();
            return View(model);
        }
        #endregion 

        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        #region ajaxCalls

        [HttpPost]
        public ActionResult SelectSuburb(Guid Rid, Guid Sid)
        {
            var venues = _facade.FetchVenue(Rid, Sid);
            var theHtml = "";
            theHtml += "<option></option>";
            foreach (IVenue v in venues)
            {
                theHtml += "<option value=\"" + v.Id + "\">" + v.VenueName + "</option>";
            }
            return Content(theHtml);
        }

        [HttpPost]
        public ActionResult SelectVenue(Guid Rid, Guid Sid, Guid Vid)
        {
            var areas = _facade.FetchArea(Rid, Sid, Vid);
            var theHtml = "";
            theHtml += "<option></option>";
            if (areas.Count() == 0)
            {
                theHtml += "<option value="+"none"+ " disabled>No areas exist for this venue.</option><option value="+"none"+" disabled>Please contact your</option><option disabled>regional coordinator.</option>";  
            }
            foreach (IArea a in areas)
            {
                theHtml += "<option value=\"" + a.Id + "\">" + a.Room + "</option>";
            }
            return Content(theHtml);
        }

        #endregion
    }



}