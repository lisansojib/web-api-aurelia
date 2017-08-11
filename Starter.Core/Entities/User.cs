using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Starter.Core.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User : IdentityUser, IEntityBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {
            DemoTables = new HashSet<DemoTableMaster>();
        }

        /// <summary>
        /// EntityState
        /// </summary>
        public EntityState EntityState { get; set; }

        /// <summary>
        /// DemoTables child collection
        /// </summary>
        public virtual ICollection<DemoTableMaster> DemoTables { get; set; }

        /// <summary>
        /// GenerateUserIdentityAsync
        /// </summary>
        /// <param name="manager">UserManager userManager</param>
        /// <param name="authenticationType">string authenticationType</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
