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
    public class Update
    {
        public Update() { }

        public Update(IEnumerable<ICourseDescription> courses) 
        {
            SetCourseDescriptions(courses); 
        }

        public static Update Instance(ICourseDescription course, IEnumerable<ICourseDescription> courses)
        {
            lock (typeof(Details))
            {
                Mapper.CreateMap<ICourseDescription, Update>(); 
                var result =  Mapper.Map<ICourseDescription,Update>(course);
                result.SetCourseDescriptions(courses);
                return result; 
            }
        }


        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid OrganizationId { get; set; }
        [Required]
        [Display(Name = "Enter the Course Name")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Enter the Course Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Enter the Course Number")]
        public string CourseNumber { get; set; }


        public void SetCourseDescriptions(IEnumerable<ICourseDescription> courses)
        {
            Mapper.CreateMap<ICourseDescription, Details>();
            var items = Mapper.Map<IEnumerable<ICourseDescription>, IEnumerable<Details>>(courses);
            CourseDescriptions = new SelectList(items, "Id", "CourseName", null);
        }

        [Display(Name = "Select a Course Description to update")]
        public SelectList CourseDescriptions { get; set; }
    }
}