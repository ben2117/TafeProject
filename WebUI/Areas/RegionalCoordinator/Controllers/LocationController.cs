using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Areas.RegionalCoordinator.Models;
using WebUI.Controllers;

namespace WebUI.Areas.RegionalCoordinator.Controllers
{
    public class LocationController : BaseController
    {
        //
        // GET: /RegionalCoordinator/Location/


        public ActionResult Index()
        {
            return View();
        }


        #region Region

        public ActionResult Region()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }


        [HttpPost]
        public ActionResult Region(WizardModel model)
        {

            try
            {
                if (model.RegionName != null)
                {
                    var newRegion = _facade.CreateRegion(model.RegionName);
                    model.RegionId = newRegion.Id;
                }
                else
                {
                    model.RegionName = _facade.FetchRegion(model.RegionId).RegionName;
                }
                TempData["suburbModel"] = model;
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                model.Regions = _facade.FetchRegion();
                return View(model);

            }
             
            
            return RedirectToAction("Suburb");
        }

        public ActionResult CreateRegion()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }


        [HttpPost]
        public ActionResult CreateRegion(WizardModel model)
        {
            try
            {
                if (model.RegionName != null)
                {
                    var newRegion = _facade.CreateRegion(model.RegionName);
                    model.RegionId = newRegion.Id;
                }
                else
                {
                    model.RegionName = _facade.FetchRegion(model.RegionId).RegionName;
                }
            }
            catch (BusinessRuleException)
            {
                ModelState.AddModelError("Exception", "Enter a region name.");
                var getRegions = _facade.FetchRegion();
                model.Regions = getRegions;
                return View(model);

            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRegion()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }


        [HttpPost]
        public ActionResult DeleteRegion(WizardModel model)
        {
            try
            {
                _facade.DeleteRegion(model.RegionId);
            }
            catch(BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                var getRegions = _facade.FetchRegion();
                model.Regions = getRegions;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateRegion()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateRegion(WizardModel model)
        {
            try
            {
                var updateRegion = _facade.UpdateRegion(model.RegionId, model.RegionName);
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                var getRegions = _facade.FetchRegion();
                model.Regions = getRegions;
                return View(model);
            }
            return View("Index");
        }

        #endregion

        #region Suburb

        [HttpGet]
        public ActionResult Suburb()
        {
            var model = (WizardModel)TempData["suburbModel"];
            model.Suburbs = _facade.FetchSuburb(model.RegionId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Suburb(WizardModel model)
        {

            var regionId = model.RegionId;
            try
            {
                if (model.SuburbName != null)
                {
                    var newSuburb = _facade.CreateSuburb(model.RegionId, model.SuburbName, model.Postcode);
                    model.SuburbId = newSuburb.Id;
                }
                else
                {
                    model.SuburbName = _facade.FetchSuburb(model.RegionId, model.SuburbId).SuburbName;
                }
                TempData["VenueModel"] = model;
                
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                model.Suburbs = _facade.FetchSuburb(model.RegionId);
                return View(model);
                
            }

            return RedirectToAction("Venue");
        }

        public ActionResult UpdateSuburb()
        {

            var model = new WizardModel();
            var suburbs = _facade.FetchAllSuburbs();
            model.Suburbs = suburbs;

            return View(model);
        }


        [HttpPost]
        public ActionResult UpdateSuburb(WizardModel model)
        {
            try
            {
                var queryResult = _facade.FetchAllSuburbs().FirstOrDefault(s => s.Id.Equals(model.SuburbId));

                Guid regionId = queryResult != null ? queryResult.RegionId : Guid.Empty;

                var updateSuburb = _facade.UpdateSuburb(regionId, model.SuburbId, model.SuburbName, model.Postcode);
                
                //var regionId = _facade.FetchSuburb(model.Suburbs.Where(s => s.Id.Equals(model.SuburbId))).Select(s => s.RegionId).FirstOrDefault();
                //var suburb = from s in model.Suburbs where s.Id.Equals(model.SuburbId) select s;

            }
            
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                var suburbs = _facade.FetchAllSuburbs();
                model.Suburbs = suburbs;
                return View(model);

            }
            
            return View("Index");
        }

        public ActionResult DeleteSuburb()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }
        
        
        [HttpPost]
        public ActionResult DeleteSuburb(Guid Rid, Guid Sid)
        {
            _facade.DeleteSuburb(Rid, Sid);
            return Content("");
        }

        public ActionResult CreateSuburb()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);

        }

        [HttpPost]
        public ActionResult CreateSuburb(WizardModel model)
        {
            try
            {
                var suburb = _facade.CreateSuburb(model.RegionId, model.SuburbName, model.Postcode);       
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                var getRegions = _facade.FetchRegion();
                model.Regions = getRegions;
                return View(model);
            }
            return View("Index");
            
        }

        #endregion

        #region Venue

        [HttpGet]
        public ActionResult Venue()
        {
            var model = (WizardModel)TempData["VenueModel"];
            model.Venues = _facade.FetchVenue(model.RegionId, model.SuburbId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Venue(WizardModel model)
        {
            try
            {
                if (model.venueName != null)
                {
                    var newVenue = _facade.CreateVenue(model.RegionId, model.SuburbId, model.venueName, model.venueAddress);
                    model.VenueId = newVenue.Id;
                }
                else
                {
                    model.venueName = _facade.FetchVenue(model.RegionId, model.SuburbId, model.VenueId).VenueName;
                }
                TempData["AreaModel"] = model;
            }
            catch (BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception", ex.Message);
                model.Venues = _facade.FetchVenue(model.RegionId, model.SuburbId);
                return View(model);
            }
            return RedirectToAction("Area");
        }

        public ActionResult CreateVenue()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateVenue(Guid regionId, Guid suburbId, string venueName, string venueAddress)
        {

            try
            {
                _facade.CreateVenue(regionId, suburbId, venueName, venueAddress);
            }
            catch(BusinessRuleException ex)
            {
                ModelState.AddModelError("Exception",ex.Message);
                return View();

            }
            return View("Index");
        }

        public ActionResult UpdateVenue()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateVenue(Guid regionId, Guid suburbId, Guid venueId, string venueName, string venueAddress)
        {
            _facade.UpdateVenue(regionId, suburbId, venueId, venueName, venueAddress);
            return View("Index");
        }

        public ActionResult DeleteVenue()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model); 
        }

        [HttpPost]
        public ActionResult DeleteVenue(Guid regionId, Guid suburbId, Guid venueId)
        {
            _facade.DeleteVenue(regionId, suburbId, venueId);
            return View("Index");
        }

        #endregion

        #region Area

        [HttpGet]
        public ActionResult Area()
        {
            var model = (WizardModel)TempData["AreaModel"];
            model.Areas = _facade.FetchArea(model.RegionId, model.SuburbId, model.VenueId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Area(WizardModel model)
        {
            try
            {
                if (model.roomNumber != null)
                {
                    var newArea = _facade.CreateArea(model.RegionId, model.SuburbId, model.VenueId, model.roomNumber);
                }
                else
                {
                    throw new BusinessRuleException("Please enter the area for this venue.");
                }
            }
            catch (BusinessRuleException ex)
            {

                
                ModelState.AddModelError("Exception", ex.Message);
                model.Areas = _facade.FetchArea(model.RegionId, model.SuburbId, model.VenueId);
                return View(model);
                
                
            }
            return View("Index");

        }

        #endregion


        #region ViewLocation

        public ActionResult ViewLocation()
        {
            var model = new WizardModel();
            var getRegions = _facade.FetchRegion();
            model.Regions = getRegions;
            return View(model);
        }


        public ActionResult SelectRegion(Guid ID)
        {
            var suburbs = _facade.FetchSuburb(ID);
            var theHtml = "";
            theHtml += "<option></option>";
            foreach (ISuburb s in suburbs)
            {
                theHtml += "<option value=\"" + s.Id + "\">" + s.SuburbName + "</option>";
            }
            return Content(theHtml);
        }


        public ActionResult SelectSuburb(Guid Sid, Guid Rid)
        {
            var venues = _facade.FetchVenue(Rid, Sid);
            var theHtml = "";
            theHtml += "<option></option>";
            foreach (IVenue v in venues)
            {
                theHtml += "<option value=\"" + v.Id + "\">" + v.VenueName + "</option>";
            }
            //var suburb = _facade.FetchSuburb(Rid, Sid);
            //var morehtml = "<h1> "+ suburb.Postcode + "</h1>";
            return Content(theHtml);
        }

        public ActionResult SelectVenue(Guid Sid, Guid Rid, Guid Vid)
        {
            var grabVenue = _facade.FetchVenue(Rid, Sid, Vid);

            var venueName = grabVenue.VenueName.ToString();
            var venueAddress = grabVenue.VenueAddress.ToString();
            var theHtml = "Venue name: " + venueName + " | Address: " + venueAddress;

            return Content(theHtml);
        }



        #endregion

    }
}
