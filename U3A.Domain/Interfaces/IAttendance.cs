using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAttendance
    {
        char Code { get; }
        Guid Id { get; set; }
        int MemberId { get; set; }
    }
}
