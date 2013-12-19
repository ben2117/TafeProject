using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{   
    internal partial class Session :ISession
    {

        IEnumerable<IAttendance> ISession.Attendances
        {
            get { return Attendances.AsEnumerable<IAttendance>();  }
        }

        internal Session(Guid classGroupId, DateTime startDate, Guid areaId)
        {
            AreaId = areaId;
            ClassGroupId = classGroupId;
            Date = startDate;
            Attendances = new HashSet<Attendance>();
        }

        internal Session UpdateSession(DateTime startDate, Guid areaId)
        {
            this.Date = startDate;
            this.AreaId = areaId;
            return this;
        }
        
        internal Attendance markAttendance(int memberId, char mark)
        {
            var attendance = Attendances.Where(a => a.MemberId.Equals(memberId)).FirstOrDefault();
            Attendance _state;

           
            switch (mark)
            {
                case 'A':
                    _state = new Absent(memberId, this.Id);
                    Attendances.Add(_state);
                    break;
                case 'P':
                    _state = new Present(memberId, this.Id);
                    Attendances.Add(_state);
                    break;
                case 'V':
                    _state = new Visitor(memberId, this.Id);
                    Attendances.Add(_state);
                    break;
            }
            return attendance;
        }
    }
}
