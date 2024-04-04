using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        readonly ApplicationDbContext _context;

        public RoleController()
        {
            _context = new ApplicationDbContext();
        }

        private ApplicationUserManager UserManager =>
            HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

        [Authorize(Roles = "admin")]
        public ActionResult AssignUserToRole
            (string email, string role)
        {
            var user = UserManager.FindByEmail(email);
            UserManager.AddToRole(user.Id, role);
            return View("AssignUserToManager",
                "", email + ":" + role);
        }

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "manager")]
        public ActionResult PayrollDetail()
        {
            return View("PayrollDetail", "",
                "My Secret Payroll Data Passing in");
        }
    }
}