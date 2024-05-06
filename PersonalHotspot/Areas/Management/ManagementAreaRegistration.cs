using System.Web.Mvc;

namespace PersonalHotspot.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Management_Default",
                "Management/{controller}/{action}/{id}",
                new { controller = "homecontents", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}