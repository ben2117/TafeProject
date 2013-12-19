using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Domain
{
    internal partial class ClassGroup :IClassGroup
    {

        IEnumerable<ISession> IClassGroup.Sessions
        {
            get { return Sessions.AsEnumerable<ISession>(); }
        }

        

        internal ClassGroup(int studentCount, Guid courseInstanceId, string classGroupName, Guid defaultArea)
        {
            DefaultAreaId = defaultArea;
            StudentCount = studentCount;
            CourseInstanceId = courseInstanceId;
            ClassGroupName = classGroupName;
            Sessions = new HashSet<Session>();

        }

        internal IClassGroup updateClassGroup(string classGroupName, Guid defaultArea, int studentCount)
        {
            this.ClassGroupName = classGroupName;
            this.DefaultAreaId = defaultArea;
            this.StudentCount = studentCount;
            return this;
        }

        internal Session CreateSession(DateTime date)
        {
            Session newSession = new Session(this.Id, date, this.DefaultAreaId);
            //VERY BAD
            newSession.Active = true; //THIS SHOULD BE IN FACADE
            
            Sessions.Add(newSession);
            return newSession;
        }

        internal IEnumerable<ISession> CreateSessions(DateTime startDate, int numberOfSessions, Frequency freq)
        {
            var gregCal = new GregorianCalendar();
            List<Session> listOfSessions = new List<Session>();

            var lastSession= CreateSession(startDate);
            listOfSessions.Add(lastSession);
            var lastSessionDate = lastSession.Date;

            for(int x = 1; x <= numberOfSessions - 1 ; ++x)
            {
               switch(freq)
               {
                   case Frequency.Daily:
                       lastSession = CreateSession(gregCal.AddDays(lastSessionDate,1));

                       break;
                   case Frequency.Fortnightly:
                       lastSession = CreateSession(gregCal.AddWeeks(lastSessionDate,2));

                       break;
                   case Frequency.Weekly:
                       lastSession = CreateSession(gregCal.AddWeeks(lastSessionDate,1));

                       break;
                   case Frequency.Monthly:
                       lastSession = CreateSession(gregCal.AddMonths(lastSessionDate,1));
                       
                       break;

               }
               lastSessionDate = lastSession.Date;
               listOfSessions.ToList().Add(lastSession);
            }
            return listOfSessions;

        }
    }  
}
