using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebUI.Areas.CourseLeader.Models
{
    public class ViewAttendance
    {
        public List<ISession> Sessions { get; set; }
    }
}