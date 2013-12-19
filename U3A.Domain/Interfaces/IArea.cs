using System;
using System.Collections.Generic;
namespace Domain
{
    public interface IArea
    {
        Guid Id { get;  }
 
        string Room { get;  }
   

        Guid VenueId { get;  }
    }
}
