using Starter.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Starter.Data.Configurations
{
    public class DemoTableMasterConfiguration : EntityTypeConfiguration<DemoTableMaster>
    {
        public DemoTableMasterConfiguration()
        {
            ToTable("DemoTableMasters");

            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Ignore(t => t.EntityState);

            HasMany(e => e.DemoTableDetails)
                .WithRequired(e => e.DemoTableMaster)
                .HasForeignKey(e => e.MasterId)
                .WillCascadeOnDelete(true);
        }
    }
}
