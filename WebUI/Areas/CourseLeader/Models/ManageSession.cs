using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebUI.Areas.CourseLeader.Models
{
    public class ManageSession
    {
        public Guid courseInstanceId { get; set; }
        public Guid regionId { get; set; }
        public Guid areaId { get; set; }
        public Guid classGroupId { get; set; }
        public Guid courseName { get; set; }
        public DateTime startDate { get; set; }
        public int numberOfSessions { get; set; }
        public Frequency freq { get; set; }
        public IEnumerable<ISession> Sessions { get; set; }
        public string classGroup { get; set; }
        
        
    }
}