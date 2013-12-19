using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IVenue
    {
   
        Guid SuburbId { get;  }
        string VenueAddress { get;  }
        string VenueName { get; }
        Guid Id { get; }
        IEnumerable<IArea> Areas { get; }
    }
}
