using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Starter.Data.Extensions
{
    public static class MappingExtensions
    {
        public static PrimitivePropertyConfiguration IsUnique(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }

        public static PrimitivePropertyConfiguration HasDefaultValue(this PrimitivePropertyConfiguration configuration)
        {
            return configuration.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}
