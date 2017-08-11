using System.Data.Entity;

namespace Starter.Core
{
    /// <summary>
    /// Entity Base Interface, all entitties will have to implement this interface
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Primary Key of the Entity
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// State of the Entity
        /// </summary>
        EntityState EntityState { get; set; }
    }
}
