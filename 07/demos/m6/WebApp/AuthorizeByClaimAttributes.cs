using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    public class AuthorizeByClaimAttributes :
        FilterAttribute, IAuthorizationFilter
    {

        public string ClaimAttributes { get; set; }

        public void OnAuthorization(AuthorizationContext 
            filterContext)
        {
            char[] delims = { ',', ';', ':', '#' };
            List<string> claimAttributesToMatchForAuthorize =
                string.IsNullOrEmpty(ClaimAttributes)
                    ? new List<string>()
                    : ClaimAttributes.Split(delims).ToList();

            var principal = 
                (ClaimsPrincipal)Thread.CurrentPrincipal;
            List<string> roleAssignedToPrincipal =
                principal.
                Claims.
                Where(a => a.Type ==
                           "RoleAssigned").
                           Select(a => a.Value).
                           Distinct().ToList();

            // check for overlap
            var authorized =
                roleAssignedToPrincipal.
                    Intersect(claimAttributesToMatchForAuthorize).Any();

            if (!authorized)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}