using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.CourseLeader.Models
{
    public class ClassGroup
    {
        public Guid Id { get; set; }
        public Guid CourseInstanceId { get; set; }

        public Guid RegionId { get; set; }
        public IEnumerable<IRegion> Regions { get; set; }

        public Guid SuburbId { get; set; }
        public IEnumerable<ISuburb> Suburbs { get; set; }

        public Guid VenueId { get; set; }
        public IEnumerable<IVenue> Venues { get; set; }

        public Guid AreaId { get; set; }
        public IEnumerable<IArea> Areas { get; set; }

        public Guid HAreaId { get; set; }
        // List of Areas
        
        public IEnumerable<SelectList> AreasList { get; set; }

        [Required]
        [Display(Name = "Number of students")]
        public int StudentCount { get; set; }

        [Required]
        [Display(Name = "Group name")]
        public string GroupName { get; set; }
    }
}