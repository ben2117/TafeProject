using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Facade : IDisposable
    {
        //DB Context
        private U3AContext _context = new U3AContext();

        //Facade Constructor
        private Organization _u3a;
        public Facade()
        {
            _u3a = FetchOrganisation();    
        }

        //TO-DO:
        //Re Loading the objects !!
        private Organization FetchOrganisation()
        {

            var organization = _context.Organizations.FirstOrDefault();
            return organization;
        }

        #region RegionManagement

        private void loadRegions()
        {

            var regions = _context.Regions.Where(r => r.Active).ToList(); 
           
        }

        public IRegion CreateRegion(string regionName)
        {
            try
            {
                loadRegions();
                var newRegion = _u3a.CreateRegion(regionName);
                newRegion.Active = true;
                _context.SaveChanges();
                return newRegion;
            }
            catch (BusinessRuleException)
            {
                throw new BusinessRuleException("Error creating region, please try again.");
            }
        }

        public IEnumerable<IRegion> FetchRegion()
        {
           
                loadRegions();
                var regions = _u3a.FetchRegion();
                return regions;
            
            
        }

        public IRegion FetchRegion(Guid regionId)
        {
            loadRegions();
            return _u3a.FetchRegion(regionId);
        }

        public IRegion UpdateRegion(Guid regionId, string regionName)
        {
            loadRegions();
            var region = _u3a.UpdateRegion(regionId, regionName);
            _context.SaveChanges();
            return region;
        }

        public void DeleteRegion(Guid regionId)
        {
                loadRegions();
                var query = FetchRegion(regionId);
                if (query.CourseInstances.Count() == 0 && query.Suburbs.Count() == 0)
                {
                    var region = _context.Regions.Where(r => r.Id == regionId).FirstOrDefault().Active = false;
                    _context.SaveChanges();
                }
                else
                {
                    throw new BusinessRuleException("This region still contains existing course instance and suburb records");
                }
                
            
           
            
            
        }
        #endregion
        
        #region SuburbManagement
        private void loadSuburbs(Guid regionId)
        {
            loadRegions();
            var suburbs = _context.Suburbs
                .Where(s => s.RegionId.Equals(regionId))
                .Where(s => s.Active).ToList(); 
        }
        
        //Adding a new suburb.
        public ISuburb CreateSuburb(Guid regionId, string suburbName, string postCode)
        {
            
                loadSuburbs(regionId);
                var newSuburb = _u3a.CreateSuburb(regionId, suburbName, postCode);
                newSuburb.Active = true;
                _context.SaveChanges();
                return newSuburb;
            
            
        }

        //Fetch all suburbs.
        public IEnumerable<ISuburb> FetchSuburb(Guid regionId)
        {
            loadSuburbs(regionId);
            var suburbs = _u3a.FetchSuburb(regionId);
            return suburbs;
            
        }

        //Fetch suburb by ID.
        public ISuburb FetchSuburb(Guid regionId, Guid suburbId)
        {
            loadSuburbs(regionId);
            return _u3a.FetchSuburb(regionId, suburbId);
        }

        public IEnumerable<ISuburb> FetchAllSuburbs()
        {
            _context.Organizations.Include("Regions.Suburbs");
            var suburbs = _context.Suburbs;
            return suburbs;
        }

        public ISuburb UpdateSuburb(Guid regionId, Guid suburbId, string suburbName, string postcode)
        {
            loadSuburbs(regionId);
            //i think that they are implicitly converted from object to interface
            var suburb = _u3a.UpdateSuburb(regionId, suburbId, suburbName, postcode);
            _context.SaveChanges();
            return suburb;
        }

        public void DeleteSuburb(Guid regionId,Guid suburbId)
        {
            loadSuburbs(regionId);
            var suburb = _context.Suburbs.Where(s => s.Id.Equals(suburbId)).FirstOrDefault().Active = false;
            _context.SaveChanges();


        }
        #endregion

        #region VenueManagement
        private void loadVenues(Guid regionId, Guid suburbId)
        {
            loadSuburbs(regionId);
            var venues = _context.Venues.Where(v => v.SuburbId.Equals(suburbId)).Where(v => v.Active).ToList();
        }
        public IVenue CreateVenue(Guid regionId, Guid suburbId, string venueName, string venueAddress)
        {
            loadVenues(regionId, suburbId);
            var newVenue = _u3a.CreateVenue(regionId, suburbId, venueName, venueAddress);
            newVenue.Active = true;
            _context.SaveChanges();
            return newVenue;
        }
        public IEnumerable<IVenue> FetchVenue(Guid regionId, Guid suburbId)
        {
            loadVenues(regionId, suburbId);
            return _u3a.FetchVenue(regionId, suburbId);
        }
        public IVenue FetchVenue(Guid regionId, Guid suburbId, Guid venueId)
        {
            loadVenues(regionId, suburbId);
            return _u3a.FetchVenue(regionId, suburbId, venueId);
        }
        public IVenue UpdateVenue(Guid regionId, Guid suburbId, Guid venueId, string venueName, string venueAddress)
        {
            loadVenues(regionId, suburbId);
            var veneu = _u3a.UpdateVenue(regionId, suburbId, venueId, venueName, venueAddress);
            _context.SaveChanges();
            return veneu;
        }

        public void DeleteVenue(Guid regionId, Guid suburbId, Guid venueId)
        {
            loadVenues(regionId,suburbId);
            var venue = _context.Venues.Where(s => s.Id.Equals(venueId)).FirstOrDefault().Active = false;
            _context.SaveChanges();
        }
        #endregion

        #region AreaManagement
        private void loadAreas(Guid regionId, Guid suburbId, Guid venueId)
        {
            loadVenues(regionId, suburbId);
            var areas = _context.Areas.Where(a => a.VenueId.Equals(venueId)).Where(v => v.Active).ToList();
        }
        public IArea CreateArea(Guid regionId, Guid suburbId, Guid venueId, string room)
        {
            
                loadAreas(regionId, suburbId, venueId);
                var newArea = _u3a.CreateArea(regionId, suburbId, venueId, room);
                newArea.Active = true;
                _context.SaveChanges();
                return newArea;
            
                
            
        }

        public IEnumerable<IArea> FetchArea(Guid regionId, Guid suburbId, Guid venueId)
        {
            loadAreas(regionId, suburbId, venueId);
            return _u3a.FetchArea(regionId, suburbId, venueId);
        }

        public IArea FetchArea(Guid regionId, Guid suburbId, Guid venueId, Guid areaId)
        {
            loadAreas(regionId, suburbId, venueId);
            return _u3a.FetchArea(regionId, suburbId, venueId, areaId);
        }

        
        public IArea UpdateArea(Guid regionId, Guid suburbId, Guid venueId, Guid areaId, string room)
        {
            loadAreas(regionId, suburbId, venueId);
            var area = _u3a.UpdateArea(regionId, suburbId, venueId, areaId, room);
            _context.SaveChanges();
            return area;
        }
        #endregion

        #region MemberManagement

        private void loadMembers()
        {
            _context.Entry(_u3a).Collection(r => (r as Organization).Members).Load();
        }

        public IMember FindOrCreateMember(int memberId)
        {
            loadMembers();
            var newMember = _u3a.findOrCreateMember(memberId);
            _context.SaveChanges();
            return newMember;    
        }

        public IEnumerable<IMember> FetchMembers()
        {
            loadMembers();
            var members = _u3a.fetchMembers();
            return members;
        }

        #endregion

        #region CourseDescriptionManagement
        private void loadCourseDescriptions(bool active)
        {
            //_context.Entry(_u3a).Collection(r => (r as Organization).CourseDescriptions).Load();
            var courseDescriptions = _context.CourseDescriptions.Where(c => c.Active == active).ToList();

        }


        public ICourseDescription CreateCourseDescription(string courseName, string courseDescription, string courseNumber =  "")
        {
            loadCourseDescriptions(true);
            CourseDescription result = null; 
            if (string.IsNullOrEmpty(courseNumber))
            {
                result = _u3a.CreateCourseDescription(courseName, courseDescription);
            }
            else
            {
                result = _u3a.CreateCourseDescription(courseName, courseDescription, courseNumber);
                result .Active = true;
            }           
            _context.SaveChanges();
            return result;
        }

        public IEnumerable<ICourseDescription> FetchCourseDescription()
        {
            loadCourseDescriptions(true);
            return _u3a.FetchCourseDescription();
        }
        public ICourseDescription FetchCourseDescription(Guid courseDescriptionId)
        {
            loadCourseDescriptions(true);
            return _u3a.FetchCourseDescription(courseDescriptionId);
        }
        public ICourseDescription UpdateCourseDescription(Guid courseDescriptionId, string courseName, string courseDescription, string courseNumber)
        {
            loadCourseDescriptions(true);
            var courseDescriotion = _u3a.UpdateCourseDescription(courseDescriptionId, courseName, courseDescription, courseNumber);
            _context.SaveChanges();
            return courseDescriotion;
        }

        //Fetch CourseDescriptions for the leader
        public IEnumerable<ICourseDescription> FetchCoursesDescriptionForLeader(bool isLoggedIn, string name)
        {
            var courseInstances = FetchCourseInstanceByLeader(isLoggedIn, name);
            List<ICourseDescription> courseDescriptions = new List<ICourseDescription>();

            foreach (var ci in courseInstances)
            {
                foreach (var cd in FetchCourseDescription())
                {
                    if (cd.Id.Equals(ci.CourseId))
                    {
                        courseDescriptions.Add(cd);
                    }
                }
            }

            return courseDescriptions;
        }

        public void DeleteCourseDescription(Guid courseDescriptionId)
        {
            loadCourseDescriptions(true);
            var courseDescription = _context.CourseDescriptions.Where(c => c.Id.Equals(courseDescriptionId)).FirstOrDefault().Active = false;
            _context.SaveChanges();
        }
        #endregion 

        #region CourseInstanceManagement
        private void loadCourseInstances(Guid regionId)
        {
            //_context.Entry(FetchRegion(regionId))
            //    .Collection(r => (r as Region).CourseInstances).Load();
            loadRegions();
           
            var courseInstances = _context.CourseInstances
                .Where(c => c.RegionId.Equals(regionId))
                .Where(c => c.Active).ToList();

        }
        public ICourseInstance createCourseInstance(Guid regionId, Guid courseDescriptionId, string courseCode, string courseLeader)
        {
            loadCourseInstances(regionId);
            var newCourseInstance = _u3a.CreateCourseInstance(regionId, courseDescriptionId, courseCode, courseLeader);
            newCourseInstance.Active = true;
            _context.SaveChanges();
            return newCourseInstance;
        }

        public IEnumerable<ICourseInstance> FetchAllCourses()
        {
            //_context.Organizations.Include("Regions")
            //    .Include("CourseDescriptions.CourseInstances")
            //    .FirstOrDefault();
            
            var courseInstances = _context.CourseInstances.Where(c => c.Active).ToList();
            return courseInstances;
        }

        public IEnumerable<ICourseInstance> FetchCourseInstanceByRegion(Guid regionId)
        {
            loadCourseInstances(regionId);
            return _u3a.FetchCourseInstanceByRegion(regionId);
        }
        public ICourseInstance FetchCourseInstanceByRegion(Guid regionId, Guid courseInstanceId)
        {
            loadCourseInstances(regionId);
            return _u3a.FetchCourseInstanceByRegion(regionId, courseInstanceId);
        }
        public ICourseInstance UpdateCourseInstance(Guid regionId, Guid courseInstanceId, string courseCode)
        {
            loadCourseInstances(regionId);
            var courseInstance = _u3a.UpdateCourseInstance(regionId, courseInstanceId, courseCode);
            _context.SaveChanges();
            return courseInstance;
        }

        //List of courses for every leader.
        private IEnumerable<ICourseInstance> fetchCoursesByLeader(string userName)
        {
            var courses = FetchAllCourses();
            List<ICourseInstance> courseList = new List<ICourseInstance>();

            foreach (var c in courses)
            {
                if (c.CourseLeader.Equals(userName))
                {
                    courseList.Add(c);
                }
            }

            return courseList;
        }

        //Validate the user.
        public IEnumerable<ICourseInstance> FetchCourseInstanceByLeader(bool isLoggedIn, string leaderName)
        {
            IEnumerable<ICourseInstance> courseList = new List<ICourseInstance>();

            if (isLoggedIn == true)
            {
                courseList = fetchCoursesByLeader(leaderName);
            }

            return courseList;
        }

        public void DisableCourseInstance(Guid courseInstanceId, Guid regionId)
        { 
            loadRegions();
            loadCourseInstances(regionId);
            var courseInstance = _context.CourseInstances.Where(c => c.Id.Equals(courseInstanceId)).FirstOrDefault().Active = false;
            _context.SaveChanges();
        }
        #endregion

        #region ClassGroupManagement
        private void loadClassGroups(Guid regionId, Guid courseInstanceId)
        {
            loadRegions();
            loadCourseInstances(regionId);
            
            //_context.Entry(FetchCourseInstanceByRegion(regionId, courseInstanceId))
            //    .Collection(c => (c as CourseInstance).ClassGroups).Load();
            var classGroups = _context.ClassGroups.Where(c => c.CourseInstanceId.Equals(courseInstanceId))
                .Where(c => c.Active).ToList();
        }
        public IClassGroup CreateClassGroup(Guid regionId, Guid courseInstanceId, int studentCount, string classGroupName, Guid defaultArea)
        {
            loadClassGroups(regionId, courseInstanceId);
            var newClassGroup = _u3a.CreateClassGroup(regionId, courseInstanceId, studentCount, classGroupName, defaultArea);
            newClassGroup.Active = true;
            _context.SaveChanges();
            return newClassGroup;
        }
        public IClassGroup FetchClassGroup(Guid regionId, Guid courseInstanceId, Guid classGroupId)
        {
            loadClassGroups(regionId, courseInstanceId);
            return _u3a.FetchClassGroup(regionId, courseInstanceId, classGroupId);
        }
        public IEnumerable<IClassGroup> FetchClassGroup(Guid regionId, Guid courseInstanceId)
        {
            loadClassGroups(regionId, courseInstanceId);
            return _u3a.FetchClassGroup(regionId, courseInstanceId);
        }

        public IClassGroup UpdateClassGroup(Guid regionId, Guid courseInstanceId, Guid classGroupId, string groupName, int studentCount, Guid defaultArea)
        {
            loadClassGroups(regionId, courseInstanceId);
            var classGroup = _u3a.UpdateClassGroup(regionId,courseInstanceId,classGroupId,groupName,studentCount,defaultArea);
            _context.SaveChanges();
            return classGroup;

        }
        #endregion

        #region SessionManagement
        private void loadSessions(Guid regionId, Guid courseInstanceId, Guid classGroupId)
        {
            loadCourseInstances(regionId);
            loadClassGroups(regionId, courseInstanceId);
            var sessions = _context.Sessions.Where(s => s.ClassGroupId.Equals(classGroupId))
                .Where(s => s.Active).ToList();
            
        }
        public IEnumerable<ISession> CreateSesssions(Guid regionId, Guid courseInstanceId, Guid classGroupId, DateTime startDate, int numberOfSessions, Frequency freq)
        {
            loadRegions();
            loadClassGroups(regionId, courseInstanceId);
            loadSessions(regionId, courseInstanceId, classGroupId);
            var newSessions = _u3a.CreateSesssions(regionId, courseInstanceId, classGroupId, startDate, numberOfSessions, freq);
            //Look into CreateSession in class group for making it active
            _context.SaveChanges();
            return newSessions;
        }
        public IEnumerable<ISession> FetchSession(Guid regionId, Guid courseInstanceId, Guid classId)
        {
            loadRegions();
            loadCourseInstances(regionId);
            loadClassGroups(regionId,courseInstanceId);
            loadSessions(regionId, courseInstanceId, classId);
            var sessions = _u3a.FetchSession(regionId, courseInstanceId, classId);
            foreach (var s in sessions)
            {
                loadAttendance(regionId, courseInstanceId, classId, s.Id);
            }
            return sessions;
        }
        public ISession FetchSession(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId)
        {
            loadSessions(regionId, courseInstanceId, classId);
            return _u3a.FetchSession(regionId, courseInstanceId, classId, sessionId);
        }

        public ISession UpdateSession(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId, Guid areaId, DateTime startDate)
        {
            loadSessions(regionId, courseInstanceId, classId);
            var session = _u3a.UpdateSession(regionId, courseInstanceId, classId, sessionId, areaId, startDate);
            _context.SaveChanges();
            return session;
        }
        #endregion

        #region AttendanceManagement
        private void loadAttendance(Guid regionId, Guid courseInstanceId, Guid classGroupId, Guid sessionId)
        {
            loadMembers();
            _context.Entry(FetchSession(regionId, courseInstanceId, classGroupId, sessionId))
                .Collection(s => (s as Session).Attendances).Load();
        }
        public IAttendance MarkAttendance(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId, int memberId, char mark)
        {
            loadAttendance(regionId, courseInstanceId, classId, sessionId);
            var attendanceMark = _u3a.MarkAttendance(regionId, courseInstanceId, classId, sessionId, memberId, mark);
            _context.SaveChanges();
            return attendanceMark;
        }

        public IEnumerable<IAttendance> FetchAttendance(Guid regionId, Guid courseInstanceId, Guid classId, Guid sessionId)
        {
            loadAttendance(regionId, courseInstanceId, classId, sessionId);
            return _u3a.FetchAttendance(regionId, courseInstanceId, classId, sessionId);
        }

        #endregion

        //Dispose the Context
        public void Dispose()
        {
            _context.Dispose();
        }       
    }
}
