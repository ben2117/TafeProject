using System;
using System.Collections.Generic;
namespace Domain
{
    public interface ISuburb
    {
        string Postcode { get;  }
        IEnumerable<IVenue> Venues { get; }
        Guid Id { get; }
        string SuburbName { get; }
        Guid RegionId { get; }
    }
}
