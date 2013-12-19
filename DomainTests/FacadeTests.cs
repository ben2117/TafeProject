using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Domain.Tests
{
    [TestClass()]
    public class FacadeTests
    {
        Facade _facade = new Facade();

        [TestMethod()]
        public void CreateRegionTest()
        {
            //var result = _facade.CreateRegion("testing");
            //var expected = "testing";

            //Assert.AreEqual(expected, result.RegionName); 
            Assert.Fail();
        }               

        [TestMethod()]
        public void FetchRegionTest()
        {
            //var guid = Guid.Parse("c1ecc2b9-3ae9-4635-b394-22711ad1b71c");
            //var result = _facade.FetchRegion(guid);

            //Assert.AreEqual(guid, result.Id);     
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateRegionTest()
        {
            //var guid = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
            //var result = _facade.UpdateRegion(guid, "test");
            //var expected = "test";
            //Assert.AreEqual(expected,result.RegionName);
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateSuburbTest()
        {
            //var guid = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
            //var result = _facade.CreateSuburb(guid, "Suburb Test", "2031");
            //var expectedName = "Suburb Test";
            //var expectedPostcode = "2031";
            //Assert.AreEqual(expectedName,result.SuburbName);
            //Assert.AreEqual(expectedPostcode, result.Postcode); 
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateSuburbTest()
        {
            //var guid = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
            //var result = _facade.UpdateSuburb(guid, Guid.Parse("15e12a76-18cc-4f0a-bab5-d409a4501279"), "NewSuburb Test", "2222");
            //var expectedName = "NewSuburb Test";
            //var expectedPostcode = "2222";
            //Assert.AreEqual(expectedName, result.SuburbName);
            //Assert.AreEqual(expectedPostcode, result.Postcode); 
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateVenueTest()
        {
            //var guidRegion = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
            //var guidSuburb = Guid.Parse("15e12a76-18cc-4f0a-bab5-d409a4501279");
            //var expectedName = "tests name";
            //var expectedAddress = "tests address";

            //var result = _facade.CreateVenue(guidRegion, guidSuburb, expectedName, expectedAddress);
            //Assert.AreEqual(expectedName,result.VenueName);
            //Assert.AreEqual(expectedAddress, result.VenueAddress);
            Assert.Fail();
        }

        //[TestMethod()]
        //public void CreateAreaTest()
        //{
        //    var guidRegion = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
        //    var guidSuburb = Guid.Parse("15e12a76-18cc-4f0a-bab5-d409a4501279");
        //    var guidVenue = Guid.Parse("a97f0f8a-4666-4271-bb0a-6c15ecb1c119");

        //    var expectedRoomNumber = "GG12577";

        //    var result = _facade.CreateArea(guidRegion, guidSuburb, guidVenue, expectedRoomNumber);
        //    Assert.AreEqual(expectedRoomNumber,result.Room);
        //}

        [TestMethod()]
        public void CreateCourseDescriptionTest()
        {
            //var expectedName="courseDescrNames Test";
            //var expectedDescription="coursesDescriptions Test";
            //var expectedCourseNumber="123456789000";
            //var result = _facade.CreateCourseDescription(expectedName, expectedDescription, expectedCourseNumber);

            //Assert.AreEqual(expectedName, result.CourseName);
            //Assert.AreEqual(expectedDescription, result.Description);
            //Assert.AreEqual(expectedCourseNumber, result.CourseNumber);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(BusinessRuleException))]
        public void DeleteVenueTest()
        {
            //var guidRegion = Guid.Parse("57ddbbe1-7bfe-4873-bbde-f96d6b622ee5");
            //var guidSuburb = Guid.Parse("15e12a76-18cc-4f0a-bab5-d409a4501279");
            //var guidVenue = Guid.Parse("a97f0f8a-4666-4271-bb0a-6c15ecb1c119");

            //var firstResult = _facade.FetchVenue(guidRegion, guidSuburb, guidVenue);
            //Assert.IsNotNull(firstResult);

            //_facade.DeleteVenue(guidRegion, guidSuburb, guidVenue);
            //var result = _facade.FetchVenue(guidRegion, guidSuburb, guidVenue);
            Assert.Fail();
        }


    }
}
