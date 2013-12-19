using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public interface IOrganization
    {
        Guid Id { get; }
        string Name { get; }
        IEnumerable<IRegion> Regions { get; }
        IEnumerable<ICourseDescription> CourseDescriptions { get; }
        IEnumerable<IMember> Members { get; }
    }
}
