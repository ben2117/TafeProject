using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Areas.RegionalCoordinator.Models.CourseDescription
{
    public class Details
    {

        public Details() { }

        public static Details Instance(ICourseDescription course)
        {
            lock (typeof(Details))
            {
                return Mapper.Map<ICourseDescription, Details>(course); 
            }
        }

        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        [Display(Name = "Enter the Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Enter the Course Description")]
        public string Description { get; set; }
        [Display(Name = "Enter the Course Number")]
        public string CourseNumber { get; set; }

    }
}