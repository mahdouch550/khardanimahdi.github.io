using System.Web;
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
            if (canAccess)
            {
                HttpCookie accessCookie = new("CanAccess", "Y")
                {
                    HttpOnly = true,
                    Secure = true
                };
                base.Response.Cookies.Add(accessCookie);
            }
            return canAccess;
        }
    }
}