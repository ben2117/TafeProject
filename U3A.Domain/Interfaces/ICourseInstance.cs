using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICourseInstance
    {
        
        string CourseCode { get; }
        Guid CourseId { get; }
        String CourseLeader { get; }
        Guid Id { get;  }
        IEnumerable<IClassGroup> ClassGroups { get; }
        Guid RegionId { get;  }
        ICourseDescription ICourseDescription { get; }
    }
}
