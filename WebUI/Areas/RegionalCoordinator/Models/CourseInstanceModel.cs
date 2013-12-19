using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace WebUI.Areas.RegionalCoordinator.Models
{
    public class CourseInstanceModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid RegionId { get; set; }
        public String CourseLeader { get; set; }
        public Guid CourseDescriptionId { get; set; }
        public string CourseCode { get; set; }
        public IEnumerable<IRegion> Regions { get; set; }
        public IEnumerable<ICourseDescription> CourseDescriptions { get; set; }
        public IEnumerable<ICourseInstance> CourseInstances { get; set; }
        public String[] CourseLeaders { get; set; }

    }
}