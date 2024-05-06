using System.Web.Mvc;

namespace PersonalHotspot.Areas.Management.Controllers
{
    [RouteArea("Management")]
    public class LoginController : Controller
    {
        [HttpPost]
        public bool Check(string typedPassword)
        {
            bool canAccess = typedPassword.Equals("baranayek");
            Session["CanAccess"] = canAccess ? "Y" : "N";
            return canAccess;
        }
    }
}