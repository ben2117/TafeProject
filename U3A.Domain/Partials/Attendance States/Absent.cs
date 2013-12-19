using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Absent : Attendance
    {
        public Absent() { }

        public Absent(int memberId, Guid sessionId) : base(memberId, sessionId) { }
        
        public override char Code
        {
            get { return 'A'; }
        }
    }
}