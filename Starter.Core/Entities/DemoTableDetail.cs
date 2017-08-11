using System;
using System.Data.Entity;

namespace Starter.Core.Entities
{
    /// <summary>
    /// DemoTableDetail Entity
    /// </summary>
    public class DemoTableDetail : IEntityBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DemoTableDetail()
        {
            Id = Guid.NewGuid().ToString();
            EntityState = EntityState.Added;
        }

        /// <summary>
        /// Primary Key
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// MasterId, Foreign Key from DemoTableMaster
        /// </summary>
        public string MasterId { get; set; }

        /// <summary>
        /// EntityState
        /// </summary>
        public EntityState EntityState { get; set; }

        /// <summary>
        /// Foreign Key table
        /// </summary>
        public virtual DemoTableMaster DemoTableMaster { get; set; }
}
}
