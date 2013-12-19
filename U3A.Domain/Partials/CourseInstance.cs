using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class CourseInstance : ICourseInstance
    {
        IEnumerable<IClassGroup> ICourseInstance.ClassGroups
        {
            get { return ClassGroups.AsEnumerable<IClassGroup>(); }
        }

        ICourseDescription ICourseInstance.ICourseDescription
        {
            get { return CourseDescription; }
        }


        internal CourseInstance(Guid courseDescriptionId, string courseCode, Guid regionId, string courseLeader)
        {
            CourseId = courseDescriptionId;
            CourseCode = courseCode;
            RegionId = regionId;
            CourseLeader = courseLeader;
            ClassGroups = new HashSet<ClassGroup>();
        }

        internal CourseInstance UpdateCourseInstance(string courseCode)
        {
            CourseCode = courseCode;
            return this;
        }

        internal ClassGroup CreateClassGroup(Guid defaultArea, int studentCount, string classGroupName)
        {
            var isClassGroup = ClassGroups.Where(g => g.ClassGroupName.Equals(classGroupName)).FirstOrDefault();
            
            if (isClassGroup == null)
            {
                var newClassGroup = new ClassGroup(studentCount, this.Id, classGroupName, defaultArea);
                ClassGroups.Add(newClassGroup);
                return newClassGroup;
            }
            else
            {                
                return isClassGroup;
            }
        }
     
    }
}
