using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class MyModel
    {
        public string MyData { get; set; }
    }
    public class Owasp04Controller : Controller
    {
        public ActionResult Index()
        {
            return View("XSSView", new MyModel
            {
                MyData =
                    "<script>alert('Hi');</script>"
            });
        }

        public ActionResult ProblemAuth()
        {
            var sessionId = Session.SessionID;
            Session["MySecret"] = "My deep dark secret here. DO NOT SHARE!";
            return Redirect("/Owasp03/Secret?id=" + sessionId);
        }


        public ActionResult ShowSecret()
        {
            var str = Session["MySecret"];
            return View("Secret", str);
        }

        public ActionResult Secret(string id)
        {
            var str = Session["MySecret"];
            if (string.IsNullOrEmpty(id))
                return View("Secret", str);
            var cookie = new HttpCookie("ASP.NET_SessionId") {Value = id};
            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return View("Secret");
        }
        //    {
        //    if (!String.IsNullOrEmpty(id))
        //{


        //public ActionResult LandingPage(string id)

        //    }
        //    var str = User.Identity.IsAuthenticated ? 
        //        "Logged in as " + User.Identity.Name :
        //        "Not Logged in";

        //    str += Session["MySecret"];
        //   // return View("LandingPage", str);
        //    return Redirect("/Owasp03/Secret");
        //}
    }
}