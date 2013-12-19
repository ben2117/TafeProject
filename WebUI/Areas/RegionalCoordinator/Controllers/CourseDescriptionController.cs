using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Areas.RegionalCoordinator.Models.CourseDescription;
using WebUI.Controllers;

namespace WebUI.Areas.RegionalCoordinator.Controllers
{
    public class CourseDescriptionController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new Create());
        }

        [HttpPost]
        public ActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.CreateCourseDescription(model.CourseName, model.Description, model.CourseNumber);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Ex", ex.Message); 
                }
            }
            return View(model); 
        }

        [HttpGet]
        public ActionResult Update()
        {
            var courses = _facade.FetchCourseDescription();
            return View(WebUI.Areas.RegionalCoordinator.Models.CourseDescription.Update.Instance(courses.First(), courses)); 
        }

        [HttpPost]
        public ActionResult Update(Update model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.UpdateCourseDescription(model.Id, model.CourseName, model.Description, model.CourseNumber);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Ex", ex.Message);
                }
            }
            model.SetCourseDescriptions(_facade.FetchCourseDescription()); 
            return View(model); 
        }


        [HttpPost]
        public ActionResult ViewCourseDescription(Guid ID)
        {
            var description = _facade.FetchCourseDescription(ID);
            var formatting = description.Description + " <br> " + description.CourseNumber;
            return Content(formatting);
        }

        public ActionResult Delete()
        {          
            return View(new Delete(_facade.FetchCourseDescription())); 
        }

        [HttpPost]
        public ActionResult Delete(Delete model)
        {
            _facade.DeleteCourseDescription(model.Id);
            return View("Index");
        }

    }
}
