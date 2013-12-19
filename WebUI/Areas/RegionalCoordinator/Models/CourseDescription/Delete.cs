using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.RegionalCoordinator.Models.CourseDescription
{
    public class Delete
    {
        public Delete() { }

        public Delete(IEnumerable<ICourseDescription> courses)
        {
             SetCourseDescriptions(courses); 
        }

        public void SetCourseDescriptions(IEnumerable<ICourseDescription> courses)
        {
            Mapper.CreateMap<ICourseDescription, Details>();
            var items = Mapper.Map<IEnumerable<ICourseDescription>, IEnumerable<Details>>(courses);
            CourseDescriptions = new SelectList(items, "Id", "Description", null); 
        }
        
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Select a Course Description for deletion")]
        public SelectList CourseDescriptions { get; set; }
    }
}