using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
namespace WebUI.Areas.CourseLeader.Models
{
    public class CourseOptions
    {
        public Guid CourseInstanceId { get; set; }
        public Guid RegionId { get; set; }
        public Guid ClassGroupId { get; set; }
        public IEnumerable<IClassGroup> ClassGroups { get; set; }
        public IEnumerable<ICourseDescription> CourseDescriptions { get; set; }

    }
}