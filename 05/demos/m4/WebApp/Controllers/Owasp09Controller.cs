using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class Owasp09Controller : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult 
            Index(string firstName,string lastName)
        {
            return View("Index");
        }
    }
}