using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebUI.Areas.CourseLeader.Models
{
    public class CreateSession
    {
        public Guid courseInstanceId { get; set; }
        public Guid regionId { get; set; }
        public Guid areaId { get; set; }
        public Guid classGroupId { get; set; }
        public IEnumerable<ICourseInstance> courseInstances { get; set; }
        public Guid courseId { get; set; }
        public IEnumerable<ICourseDescription> courseDescriptons { get; set; }
        public DateTime startDate { get; set; }
        public int numberOfSessions { get; set; }
        public Frequency freq { get; set; }
        public string userName { get; set; }
        public Guid sessionId { get; set; }
        
        public string minute { get; set; }

        public IEnumerable<String> frequancy { get; set; }

        public CreateSession()
        {
            var _frequancy = new List<String>();
            _frequancy.Add("Daily");
            _frequancy.Add("Weekly");
            _frequancy.Add("Fortnightly");
            _frequancy.Add("Monthly");

            frequancy = _frequancy;
        }
        public string hour { get; set; }
    }
}