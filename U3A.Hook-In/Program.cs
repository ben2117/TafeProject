using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace U3A.Hook_In
{
    class Program
    {
        static void Main(string[] args)
        {

            var facade = new Facade();
            var regionGuid = new Guid("c1ecc2b9-3ae9-4635-b394-22711ad1b71c");

            var theRegion = facade.FetchRegion(regionGuid);

            var x = 3;
            x++;
            //var changedRegion = facade.UpdateRegion(new Guid("2ff3da65-144e-4384-a7d7-e1af7c4ce56d"), "THIS WORKED");
            //var thesubs = facade.FetchSuburb(theRegion.Id).FirstOrDefault();
            //var theVenue = facade.FetchVenue(theRegion.Id, thesubs.Id).FirstOrDefault();

            //var theArea = facade.CreateArea(theRegion.Id, thesubs.Id, theVenue.Id, "Room 25");
            //var theCourseD = facade.FetchCourseDescription().FirstOrDefault();
            //var thecinstance = facade.createCourseInstance(theRegion.Id, theCourseD.Id, "hehe");
            //var thegroup = facade.CreateClassGroup(theRegion.Id, thecinstance.Id, 16, "Class A", theArea.Id);
            //var theSessions = facade.CreateSesssions(theRegion.Id, thecinstance.Id, thegroup.Id, DateTime.Now, 16, Frequency.Weekly);
            ////var member = facade.FindOrCreateMember(456789);
            //var markOneAttendace = facade.MarkAttendance(theRegion.Id, thecinstance.Id, thegroup.Id, theSessions.FirstOrDefault().Id, 7756, 'A');
            
                
            
        }
    }
}
