using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApp.Models
{
    public class ApplicationUserStore<TUser> : UserStore<TUser>
        where TUser : ApplicationUser
    {
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }

        public int TenantId { get; set; }


        public override Task CreateAsync(TUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.TenantId = TenantId;
            return base.CreateAsync(user);
        }

        public override Task<TUser> FindByEmailAsync(string email)
        {
            return GetUserAggregateAsync(u => u.Email.ToUpper() == email.ToUpper()
                                              && u.TenantId == TenantId);
        }

        public override Task<TUser> FindByNameAsync(string userName)
        {
            return GetUserAggregateAsync(u => u.UserName.ToUpper() == userName.ToUpper()
                                              && u.TenantId == TenantId);
        }
    }
}