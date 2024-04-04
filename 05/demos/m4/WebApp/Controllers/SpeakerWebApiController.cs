using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.ControllerWebApi;
using WebApp.Models;

namespace WebApp.Controllers
{
    
    public class SpeakerWebApiController : MultiTenantWebApiController
    {
        // GET: api/SpeakerWebApi
        [Authorize]
        public IEnumerable<Speaker> Get()
        {
            List<Speaker> speakers;
            using (var db = new ApplicationDbContext())
            {
                int tenantId = Tenant.Id;
                speakers = db.Speakers.
                    Where(a => a.TenantId == tenantId).ToList();
            }
            return speakers;
        }

        // GET: api/SpeakerWebApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpeakerWebApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SpeakerWebApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpeakerWebApi/5
        public void Delete(int id)
        {
        }
    }
}
