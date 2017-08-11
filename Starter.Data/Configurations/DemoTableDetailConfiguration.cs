using Starter.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Starter.Data.Configurations
{
    public class DemoTableDetailConfiguration : EntityTypeConfiguration<DemoTableDetail>
    {
        public DemoTableDetailConfiguration()
        {
            ToTable("DemoTableDetails");

            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Ignore(t => t.EntityState);
        }
    }
}
