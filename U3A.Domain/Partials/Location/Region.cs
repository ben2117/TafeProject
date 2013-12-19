using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Region:IRegion
    {
        IEnumerable<ISuburb> IRegion.Suburbs { get { return Suburbs; } }

        IEnumerable<ICourseInstance> IRegion.CourseInstances { get { return CourseInstances; } }

        public Region(Guid organizationId, string regionName)
        {
            RegionName = regionName;
            OrganizationId = organizationId;
        }

        internal Region UpdateRegion(string regionName, Guid orgranizationId)
        {
            RegionName = regionName;
            OrganizationId = orgranizationId;

            return this;
        }

        internal Suburb CreateSuburb(string suburbName, string postCode)
        {
            var isSuburb = Suburbs.Where(s => s.SuburbName.Equals(suburbName)).FirstOrDefault();
            if (isSuburb == null)
            {
                var newSuburb = new Suburb(this.Id, suburbName, postCode);
                Suburbs.Add(newSuburb);
                return newSuburb;
            }
            else
            {
                //throw new Exception("Alredy Exsists");
                return isSuburb;
            }

        }

        internal CourseInstance CreateCourseInstance(Guid courseDescriptionId, string courseCode, string courseLeader)
        {
            var isCourse = CourseInstances.Where(c => c.CourseId.Equals(courseCode)).FirstOrDefault();
            if (isCourse == null)
            {
                var newCourse = new CourseInstance(courseDescriptionId, courseCode, this.Id, courseLeader);
                CourseInstances.Add(newCourse);
                return newCourse;
            }
            else
            {
                throw new Exception("Alredy Exsists");
                //return isCourse;
            }
        }


     
    }
}
