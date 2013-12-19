using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Organization : IOrganization
    {
        
        
        #region Properties

        IEnumerable<IRegion> IOrganization.Regions
        {
            get { return Regions; }
        }

        IEnumerable<ICourseDescription> IOrganization.CourseDescriptions
        {
            get { return CourseDescriptions; }
        }

        IEnumerable<IMember> IOrganization.Members
        {
            get { return Members.AsEnumerable<IMember>(); }
        }

        #endregion

        #region RegionCRUD

        internal Region CreateRegion(string regionName)
        {
            var newRegion = new Region(this.Id, regionName);
            this.Regions.Add(newRegion);

            return newRegion;
        }

        internal IEnumerable<Region> FetchRegion()
        {
            var regionList = Regions.AsEnumerable();
            return regionList;
        }

        internal Region FetchRegion(Guid regionId)
        {
            var region = Regions.Where(r => r.Id.Equals(regionId)).FirstOrDefault();
            if (region != null)
            {
                return region;
            }
            else
            {
                throw new BusinessRuleException("Select a region or type in a new region name.");
            }


        }

        internal Region UpdateRegion(Guid regionId, string regionName)
        {
            if (regionId != null && regionName != null)
            {
                return FetchRegion(regionId).UpdateRegion(regionName, this.Id);
            }
            else
            {
                throw new BusinessRuleException("Select a region and type in a new region name.");
            }
        }

        //internal bool DeleteRegion(Guid regionId)
        //{
            
        //    var deleteRegion = FetchRegion(regionId);

        //    if (deleteRegion.Suburbs.Count == 0 && deleteRegion.CourseInstances.Count == 0)
        //    {
        //        return true;
        //    }
        //    else 
        //    {
        //        throw new BusinessRuleException("This region contains existing suburbs and course instances.");
        //    }

        //}

        #endregion

        #region SubrubCRUD
        //Adding a new suburb.
        internal Suburb CreateSuburb(Guid regionId, string suburbName, string postCode)
        {
            try
            {

                return FetchRegion(regionId).CreateSuburb(suburbName, postCode);
            }
            catch (Exception)
            {
                throw new BusinessRuleException("Select a region and type a new suburb name & postcode.");
            }
            
            
        }

        //Fetch all suburbs.
        internal IEnumerable<Suburb> FetchSuburb(Guid regionId)
        {
            
                var suburbs = FetchRegion(regionId).Suburbs.AsEnumerable();
                if (suburbs != null)
                {
                    return suburbs;
                }
                else
                {
                    throw new BusinessRuleException("Select a suburb or type in a new suburb name & postcode.");
                }
            
             
        }

        //Fetch suburb by ID.
        internal Suburb FetchSuburb(Guid regionId, Guid suburbId)
        {
            var suburbs = FetchSuburb(regionId).Where(s => s.Id.Equals(suburbId)).FirstOrDefault();
            if (suburbs != null)
            {
                return suburbs;

            }
            else
            {
                throw new BusinessRuleException("Select a suburb or type in a new suburb name & postcode.");
            }

        }

        //Update Suburb.
        internal Suburb UpdateSuburb(Guid regionId, Guid suburbId, string suburbName, string postcode)
        {
            if (regionId != null && suburbName != null && postcode != null)
            {
                return FetchSuburb(regionId, suburbId).UpdateSuburb(suburbName, postcode);
            }
            else
            {
                throw new BusinessRuleException("Select an existing suburb and enter a new suburb name & postcode.");
            }
            
        }

        #endregion

        #region VenueCRUD
        internal Venue CreateVenue(Guid regionId, Guid suburbId, String venueName, String venueAddress)
        {
            if (regionId != null || suburbId != null || venueName != null || venueAddress != null)
            {
                return FetchSuburb(regionId, suburbId).CreateVenue(venueName, venueAddress);
            }
            else
            {
                throw new BusinessRuleException("Select a region & suburb and type in a new venue name and address.");
            }
            
            
        }
        internal IEnumerable<Venue> FetchVenue(Guid regionId, Guid suburbId)
        {
            return FetchSuburb(regionId, suburbId).Venues.AsEnumerable();
        }
        internal Venue FetchVenue(Guid regionId, Guid suburbId, Guid venueId)
        {
            
            var venues = FetchVenue(regionId, suburbId).Where(v => v.Id.Equals(venueId)).FirstOrDefault();
            if (venues != null)
            {
                return venues;
            }
            else
            {
                throw new BusinessRuleException("Please select a venue or enter new venue details.");
            }
        }
        internal Venue UpdateVenue(Guid regionId, Guid suburbId, Guid venueId, String venueName, String venueAddress)
        {
            return FetchVenue(regionId, suburbId, venueId).UpdateRegion(venueName, venueAddress);
        }

        #endregion

        #region AreaCRUD
        internal Area CreateArea(Guid regionId, Guid suburbId, Guid venueId, string room)
        {
            
            var area = FetchVenue(regionId, suburbId, venueId).CreateArea(room);
            if (room != null)
            {
                return area;

            }
            else
            {
                throw new BusinessRuleException("Please enter the area for this venue");
            }
        }
        internal IEnumerable<Area> FetchArea(Guid regionId, Guid suburbId, Guid venueId)
        {
            return FetchVenue(regionId, suburbId, venueId).Areas.AsEnumerable();
        }
        internal Area FetchArea(Guid regionId, Guid suburbId, Guid venueId, Guid areaId)
        {
            return FetchArea(regionId, suburbId, venueId).Where(a => a.Id.Equals(areaId)).FirstOrDefault();
        }
        internal Area UpdateArea(Guid regionId, Guid suburbId, Guid venueId, Guid areaId, string room)
        {
            return FetchArea(regionId, suburbId, venueId, areaId).updateArea(room);
        }
        #endregion

        #region MemberCRUD
        internal Member findOrCreateMember(int memberId)
        {

            var isMember = Members.Where(m => m.Id.Equals(memberId)).FirstOrDefault();

            if (isMember == null)
            {
                var newMember = new Member(this.Id, memberId);
                Members.Add(newMember);
                return newMember;
            }
            else
            {
                return isMember;
            }
        }

        //Fetch All Members
        internal IEnumerable<IMember> fetchMembers()
        {
            var members = Members;
            return members;
        }

        #endregion

        #region CourseDescriptionCRUD

        internal CourseDescription CreateCourseDescription(string courseName, string courseDescription)
        {
            //auto generates course number if it is not supplied 
            var courseNumber = (from no in CourseDescriptions
                                select no.CourseNumber).Max() + 1;

            return creationOfCourseDescription(courseName, courseDescription, courseNumber);
        }

        internal CourseDescription CreateCourseDescription(string courseName, string courseDescription, string courseNumber)
        {
            return creationOfCourseDescription(courseName, courseDescription, courseNumber);
        }

        internal CourseDescription creationOfCourseDescription(string courseName, string courseDescription, string courseNumber)
        {
            var isCourse = CourseDescriptions.Where(c => c.CourseNumber.Equals(courseNumber)).FirstOrDefault();

            if (isCourse == null)
            {
                var newCourse = new CourseDescription(this.Id, courseName, courseDescription, courseNumber);
                this.CourseDescriptions.Add(newCourse);
                return newCourse;
            }
            else
            {
                throw new BusinessRuleException("Course Alredy Exsists");
                //return isCourse;
            }
        }

        internal IEnumerable<ICourseDescription> FetchCourseDescription()
        {
            
            var courseDescriptions = CourseDescriptions.AsEnumerable();
            return courseDescriptions;
        }
        internal CourseDescription FetchCourseDescription(Guid courseDescriptionId)
        {
            var courseDescription = CourseDescriptions.Where(c => c.Id.Equals(courseDescriptionId)).FirstOrDefault();
            return courseDescription;
        }
        internal CourseDescription UpdateCourseDescription(Guid courseDescriptionId, string courseName, string courseDescription, string courseNumber)
        {
            return FetchCourseDescription(courseDescriptionId).updateCourseDescription(courseName, courseDescription, courseNumber);
            //What happens when im coding for too long
            //return FetchCourseDescription(courseDescriptionId, courseName, courseDescription, courseNumber);
        }


        #endregion

        #region CourseInstanceCRUD
        internal CourseInstance CreateCourseInstance(Guid regionId, Guid courseDescriptionId, string courseCode, string courseLeader)
        {
            var region = FetchRegion(regionId);
            return region.CreateCourseInstance(courseDescriptionId, courseCode, courseLeader);
        }
        internal IEnumerable<CourseInstance> FetchCourseInstanceByCourse(Guid courseDescriptionId)
        {
            return FetchCourseDescription(courseDescriptionId).CourseInstances.AsEnumerable();
        }
        internal IEnumerable<CourseInstance> FetchCourseInstanceByRegion(Guid regionId)
        {
            
            
            return FetchRegion(regionId).CourseInstances.AsEnumerable();
            
        }
        
        
        internal CourseInstance FetchCourseInstanceByRegion(Guid regionId, Guid courseInstanceId)
        {
            var test = FetchRegion(regionId).CourseInstances.Where(c => c.Id.Equals(courseInstanceId)).FirstOrDefault();
            return test;
        }
        internal CourseInstance UpdateCourseInstance(Guid regionId, Guid courseInstanceId, string courseCode)
        {
            return FetchCourseInstanceByRegion(regionId, courseInstanceId).UpdateCourseInstance(courseCode);
        }

        #endregion

        #region ClassGroupCRUD
        internal ClassGroup CreateClassGroup(Guid regionId, Guid courseInstanceId, int studentCount, string classGroupName, Guid AreaId)
        {
            return FetchCourseInstanceByRegion(regionId, courseInstanceId).CreateClassGroup(AreaId, studentCount, classGroupName);
            
        }

        internal ClassGroup FetchClassGroup(Guid regionId, Guid courseInstanceId, Guid classGroupId)
        {
            return FetchCourseInstanceByRegion(regionId, courseInstanceId).ClassGroups.Where(c => c.Id.Equals(classGroupId)).FirstOrDefault();
        }

        internal IEnumerable<ClassGroup> FetchClassGroup(Guid regionId, Guid courseInstanceId)
        {
            return FetchCourseInstanceByRegion(regionId, courseInstanceId).ClassGroups.AsEnumerable();
        }

        internal IClassGroup UpdateClassGroup(Guid regionId, Guid courseInstanceId, Guid classGroupId, string groupName, int studentCount, Guid defaultArea)
        {
            var classGroup = FetchClassGroup(regionId, courseInstanceId, classGroupId);
            classGroup.updateClassGroup(groupName, defaultArea, studentCount);
            return classGroup;
        }
        #endregion

        #region Sessions
        internal IEnumerable<ISession> CreateSesssions(Guid regionId, Guid courseInstanceId, Guid classGroupId, DateTime startDate, int numberOfSessions, Frequency freq)
        {
            return FetchClassGroup(regionId, courseInstanceId, classGroupId).CreateSessions(startDate, numberOfSessions, freq);
        }
        internal IEnumerable<Session> FetchSession(Guid regionId, Guid courseInstanceId, Guid classId)
        {
            return FetchClassGroup(regionId, courseInstanceId, classId).Sessions.AsEnumerable();
        }
        internal Session FetchSession(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId)
        {
            var g = FetchClassGroup(regionId, courseInstanceId, classId);
            var s = g.Sessions;
            var ss = s.Where(x => x.Id.Equals(sessionId)).FirstOrDefault();
            return ss;
        }
        internal IEnumerable<Session> FetchSession(Guid regionId, Guid courseInstanceId, Guid classId, DateTime date)
        {
            return FetchClassGroup(regionId, courseInstanceId, classId).Sessions.Where(s => s.Date.DayOfYear.Equals(date.DayOfYear));
        }

        internal ISession UpdateSession(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId, Guid areaId, DateTime startDate)
        {
            var session = FetchSession(regionId, courseInstanceId, classId, sessionId);
            session.UpdateSession(startDate, areaId);
            return session;
        }
        #endregion

        #region Attendance

        internal Attendance MarkAttendance(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId, int memberId, char mark)
        {
            var attendance = FetchAttendance(regionId, courseInstanceId, classId, sessionId);
            Boolean found = false;
            foreach (var a in attendance)
            {
                if (memberId == a.MemberId)
                {
                    found = true;
                }
            }
            if (!found)
            {
                var member = findOrCreateMember(memberId);
                return FetchSession(regionId, courseInstanceId, classId, sessionId).markAttendance(member.Id, mark);
            }
            else
            {
                throw new BusinessRuleException("THERE IS ALREDY A MEMBER FOR THIS SESSION");
            }
            
        }
        internal IEnumerable<IAttendance> FetchAttendance(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId)
        {
            return FetchSession(regionId, courseInstanceId, classId, sessionId).Attendances.AsEnumerable();
        }
        #endregion      
    }
}