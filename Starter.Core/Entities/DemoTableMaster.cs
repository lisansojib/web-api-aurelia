using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Starter.Core.Entities
{
    /// <summary>
    /// DemoTableMaster Entity
    /// </summary>
    public class DemoTableMaster : IEntityBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DemoTableMaster()
        {
            Id = Guid.NewGuid().ToString();
            EntityState = EntityState.Added;
            DemoTableDetails = new HashSet<DemoTableDetail>();
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
        /// User Id, Foreign Key from User table
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// EntityBase
        /// </summary>
        public EntityState EntityState { get; set; }

        /// <summary>
        /// Foreign Key table
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// DemoTableDetails child collection
        /// </summary>
        public virtual ICollection<DemoTableDetail> DemoTableDetails { get; set; }
    }
}