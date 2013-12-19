using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Area : IArea
    {
        internal Area(Guid venueId, string room)
        {
            VenueId = venueId;
            Room = room;
        }

        internal Area updateArea(string room)
        {
            this.Room = room;
            return this;
        }
    }
}
