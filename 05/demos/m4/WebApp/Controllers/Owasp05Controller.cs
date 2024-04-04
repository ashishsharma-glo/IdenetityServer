using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class Owasp05Controller : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}