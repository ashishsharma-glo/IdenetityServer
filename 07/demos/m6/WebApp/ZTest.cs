//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Mvc;
//using FilterAttribute = System.Web.Http.Filters.FilterAttribute;
//using IAuthorizationFilter = System.Web.Http.Filters.IAuthorizationFilter;

//namespace WebApp
//{
//    public class AuthorizeByClaimAttributes :
//        FilterAttribute, IAuthorizationFilter
//    {
//        public string ClaimAttributes { get; set; }

//        private readonly char[] _delims = { ',', ';', ':', '#' };

//        /// <summary>
//        /// check to see if overlap between claims typed on attribute
//        /// and claims associated with user
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public void OnAuthorization
//            (AuthorizationContext filterContext)
//        {
//            List<string> claimAttributesToMatchForAuthorize =
//                string.IsNullOrEmpty(ClaimAttributes)
//                    ? new List<string>()
//                    : ClaimAttributes.Split(_delims).ToList();

//            var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
//            List<string> roleAssignedToPrincipal =
//                principal.Claims.Where(a => a.Type == "RoleAssigned").
//                    Select(a => a.Value).Distinct().ToList();

//            // check for overlap
//            var authorized =
//                roleAssignedToPrincipal.
//                    Intersect(claimAttributesToMatchForAuthorize).Any();

//            if (!authorized)
//            {
//                filterContext.Result = new HttpUnauthorizedResult();
//            }
//        }

       
//    }
//}