using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Areas.CourseLeader.Models
{
    public class CourseLeader
    {
       public string Name { get; set; }
       public IEnumerable<ICourseInstance> Courses { get; set; }
       public IEnumerable<ICourseDescription> CourseDescription { get; set; }
       public Guid lastCourseInstanceId { get; set; }
       public string courseDescription { get; set; }
    }
}