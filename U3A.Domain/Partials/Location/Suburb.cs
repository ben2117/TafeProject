using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Suburb:ISuburb 
    {
        IEnumerable<IVenue> ISuburb.Venues { get { return Venues; } } 

        internal Suburb(Guid regionId,string suburbName, string postCode)
        {
            RegionId = regionId;
            SuburbName = suburbName;
            Postcode = postCode;
        }

        //Update Suburb.
        internal Suburb UpdateSuburb(string suburbName, string postcode)
        {
            this.SuburbName = suburbName;
            this.Postcode = postcode;
            return this;
        }

        internal Venue CreateVenue(string venueName, string venueAddress)
        {
            var isVenue = Venues.Where(v => v.VenueAddress.Equals(venueAddress)).FirstOrDefault();
            if (isVenue == null)
            {
                var newVenue = new Venue(this.Id, venueName, venueAddress);
                Venues.Add(newVenue);
                return newVenue;
            }
            else
            {
                throw new Exception("Alredy Exsists");
                //return isVenue;
            }

        }


    }
}
