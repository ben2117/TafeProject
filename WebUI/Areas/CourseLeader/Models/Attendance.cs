using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebUI.Areas.CourseLeader.Models
{
    public class Attendance
    {
        public Guid courseInstanceId { get; set; }
        public Guid regionId { get; set; }
        public Guid areaId { get; set; }
        public Guid classGroupId { get; set; }
        public Guid sessionId { get; set; }
        public IEnumerable<IAttendance> attendances { get; set; }

        public int memberId { get; set; }
        public Frequency freq { get; set; }

        public IEnumerable<String> state { get; set; }

        public Attendance()
        {
            var _state = new List<String>();
            _state.Add("Visitor");
            _state.Add("Present");
            _state.Add("Absent");

            state = _state;
        }

    }
}