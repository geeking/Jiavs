using Jiavs.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jiavs.Infrastructure.Identity.Data
{
    public class UserContext : IdentityDbContext<JiavsUser, Role, uint>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<JiavsUser>().ToTable(nameof(JiavsUser));
            //builder.Entity<Role>().ToTable(nameof(Role));
            //builder.Entity<IdentityRoleClaim<uint>>().ToTable("RoleClaim");
            //builder.Entity<IdentityUserClaim<uint>>().ToTable("UserClaim");
            //builder.Entity<IdentityUserRole<uint>>().ToTable("UserRole");
            //builder.Entity<IdentityUserLogin<uint>>().ToTable("UserLogin");
            //builder.Entity<IdentityUserToken<uint>>().ToTable("UserToken");

        }
    }
}
