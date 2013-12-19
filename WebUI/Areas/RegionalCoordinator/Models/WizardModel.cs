using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WebUI.Areas.RegionalCoordinator.Models
{
    public class WizardModel
    {
        [Required(ErrorMessage = "Please enter a region name")]
        [Display(Name = "Modify the name of the selected region")]
        public string RegionName { get; set; }      
  
        [Required(ErrorMessage="Please select a region")]
        [Display(Name = "Select a Region")]
        public Guid RegionId { get; set; }
        public IEnumerable<IRegion> Regions { get; set; }

        [Required(ErrorMessage = "Please enter a suburb name")]
        [Display(Name = "Enter a suburb name")]
        public string SuburbName { get; set; }
        [Required(ErrorMessage = "Please enter a postcode")]
        [Display(Name = "Enter a post code")]
        public string Postcode { get; set; }
        public Guid SuburbId { get; set; }
        public IEnumerable<ISuburb> Suburbs { get; set; }
        public List<ISuburb> SuburbList { get; set; }

        [Required(ErrorMessage = "Please enter a venue name")]
        [Display(Name = "Enter a venue name")]
        public string venueName { get; set; }
        [Required(ErrorMessage = "Please enter an address")]
        [Display(Name = "Enter a venue address")]
        public string venueAddress { get; set; }
        public Guid VenueId { get; set; }
        public IEnumerable<IVenue> Venues { get; set; }

        [Display(Name="Existing Areas")]
        public Guid AreaId { get; set; }


        public IEnumerable<IArea> Areas { get; set; }
        [Required(ErrorMessage = "Please enter a area name")]
        [Display(Name = "Enter a room number")]
        public string roomNumber { get; set; }
    }
}