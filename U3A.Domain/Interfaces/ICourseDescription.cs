using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ICourseDescription
    {
        
        Guid Id { get; }
        Guid OrganizationId { get; }
        string CourseName { get; }
        string Description { get; }
        String CourseNumber { get; }
        //IEnumerable<ICourseInstance> CourseInstances { get; }
    }
}
