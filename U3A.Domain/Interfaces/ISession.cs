using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISession
    {
        Guid Id { get; }
        Guid ClassGroupId { get; }
        Guid AreaId { get; }
        DateTime Date { get; }
        IEnumerable<IAttendance> Attendances { get; }
    }
}
