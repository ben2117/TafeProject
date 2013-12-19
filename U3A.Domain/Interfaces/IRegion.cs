using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRegion
    {
        Guid Id { get; }
        String RegionName { get; }
        IEnumerable<ISuburb> Suburbs {get;}
        IEnumerable<ICourseInstance> CourseInstances { get; }
    }
}
