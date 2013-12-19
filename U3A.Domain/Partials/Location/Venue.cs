using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Venue:IVenue
    {
        IEnumerable<IArea> IVenue.Areas { get { return Areas; } } 

        internal Venue(Guid suburbId, String venueName, String venueAddress)
        {
            SuburbId = suburbId;
            VenueName = venueName;
            VenueAddress = venueAddress;
        }
        internal Venue UpdateRegion(string venueName, string venueAddress)
        {
            this.VenueName = venueName;
            this.VenueAddress = venueAddress;
            return this;
        }

        internal Area CreateArea(string room)
        {
            var isarea = Areas.Where(a => a.Room.Equals(room)).FirstOrDefault();
            if (isarea == null)
            {
                var newArea = new Area(this.Id, room);
                Areas.Add(newArea);
                return newArea;
            }
            else
            {
                
                return isarea;
            }
        }

    }
}
