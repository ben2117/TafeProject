using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Present : Attendance
    {
        public Present() { }

        public Present(int memberId, Guid sessionId) : base(memberId, sessionId) { }
        
        public override char Code
        {
            get { return 'P'; }
        }
    }
}
