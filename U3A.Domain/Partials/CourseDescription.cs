using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class CourseDescription:ICourseDescription 
    {
        //IEnumerable<ICourseInstance> CourseInstances { get;}

        internal CourseDescription(Guid organizationId, string courseName, string courseDescription, string courseNumber)
        {

            OrganizationId = organizationId;
            CourseName = courseName;
            Description = courseDescription;
            CourseNumber = courseNumber;

        }

        internal CourseDescription updateCourseDescription( string courseName, string courseDescription, string courseNumber)
        {
            this.CourseName = courseName;
            this.Description = courseDescription;
            this.CourseNumber = courseName;
            return this;
        }


        Guid ICourseDescription.OrganizationId
        {
            get { return this.OrganizationId;  }
        }
    }
}
