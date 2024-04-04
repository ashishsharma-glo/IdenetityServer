using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebApp.Controllers
{
    public class ClaimController : Controller
    {
        public ApplicationUserManager UserManager =>
            HttpContext.GetOwinContext().
                GetUserManager<ApplicationUserManager>();

        [AuthorizeByClaimAttributes
            (ClaimAttributes = "admin,manager")]


        public ActionResult PayrollOperation()
        {
            return View();
        }

        [Authorize
            (Roles = "admin,manager")]


        public ActionResult AddManagerClaimToUser
            (string email)
        {
            var user = UserManager.FindByEmail(email);
            UserManager.AddClaim(user.Id,
                new Claim("RoleAssigned", "manager"));
            return View("AddManagerClaimToUser", "", email);

        }


        // GET: Claim
        public ActionResult Index()
        {
            return View();
        }
    }
}