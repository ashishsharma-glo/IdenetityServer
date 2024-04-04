using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;

namespace WebApp.Controllers
{
   
    public class Owasp03Controller : Controller
    {
        public ActionResult Index()
        {

            return View();
        }


        //public ActionResult LandingPage(string id)
        //{
        //    if (!String.IsNullOrEmpty(id))
        //    {

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
