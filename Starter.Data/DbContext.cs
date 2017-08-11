using Microsoft.AspNet.Identity.EntityFramework;
using Starter.Core.Entities;
using Starter.Data.Configurations;
using System.Data.Entity;

namespace Starter.Data
{
    public class DbContext : IdentityDbContext<User>
    {
        public DbContext()
             : base("DbConnectionString", throwIfV1Schema: false)
        {
        }

        public static DbContext Create()
            => new DbContext();

        public virtual IDbSet<DemoTableDetail> DemoTableDetailSet { get; set; }

        public virtual IDbSet<DemoTableMaster> DemoTableMasterSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            modelBuilder.Configurations.Add(new DemoTableDetailConfiguration());
            modelBuilder.Configurations.Add(new DemoTableMasterConfiguration());
        }
    }
}
