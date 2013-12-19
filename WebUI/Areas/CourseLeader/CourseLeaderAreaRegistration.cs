using System.Web.Mvc;

namespace WebUI.Areas.CourseLeader
{
    public class CourseLeaderAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CourseLeader";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CourseLeader_default",
                "CourseLeader/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
