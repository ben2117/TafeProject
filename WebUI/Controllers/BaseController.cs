using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using System.Web.Caching;

namespace WebUI.Controllers
{
//    public class DebugAuthorizeAttribute : AuthorizeAttribute
//    {
//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {
//            bool disableAuthentication = false;

//#if DEBUG
//            disableAuthentication = true;
//#endif

//            if (disableAuthentication)
//                return true;

//            return base.AuthorizeCore(httpContext);
//        }
//    }
    
    [Authorize]
    public class BaseController : Controller
    {
        protected Facade _facade = new Facade();

        protected Guid UserID
        {
            get
            {

               
                return (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _facade.Dispose();
            base.Dispose(disposing);
        }

    }
}
