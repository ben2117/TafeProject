using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal partial class Member:IMember 
    {
        internal Member(Guid organisationId, int memberId)
        {
            OrganizationId = organisationId;
            Id = memberId;
        }
    }
}
