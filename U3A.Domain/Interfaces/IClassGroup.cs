using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IClassGroup
    {
        Guid Id { get; }
        int StudentCount { get; }
        IEnumerable<ISession> Sessions { get; }
        string ClassGroupName { get; }
        Guid DefaultAreaId { get;}
        
    }
}
