using Starter.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Starter.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            Ignore(t => t.EntityState);

            HasMany(e => e.DemoTables)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
