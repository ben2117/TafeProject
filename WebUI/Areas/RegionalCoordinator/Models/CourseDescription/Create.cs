using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Areas.RegionalCoordinator.Models.CourseDescription
{
    public class Create
    {
        public Create() { }

        [Required]
        public Guid OrganizationId { get; set; }

        [Required(ErrorMessage = "Please enter a course name")]
        [Display(Name = "Enter the Course Name")]
        public string CourseName { get; set; }
           
        [Display(Name = "Enter the Course Description")]
        [Required(ErrorMessage = "Please enter a course description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a course number")]
        [Display(Name = "Enter the Course Number")]
        public string CourseNumber { get; set; }
    }
}