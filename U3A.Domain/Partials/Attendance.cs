using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal abstract partial class Attendance : Domain.IAttendance
    {
        public Attendance() { }

        public Attendance(int memberId, Guid sessionId)
        {
            SessionId = sessionId;
            MemberId = memberId; 
        }
        public abstract char Code { get; }

    }
}
