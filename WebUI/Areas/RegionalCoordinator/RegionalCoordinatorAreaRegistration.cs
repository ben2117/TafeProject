using System.Web.Mvc;

namespace WebUI.Areas.RegionalCoordinator
{
    public class RegionalCoordinatorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RegionalCoordinator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RegionalCoordinator_default",
                "RegionalCoordinator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
