using Microsoft.EntityFrameworkCore;

namespace OneWork.Server.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class OneWorkDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public OneWorkDbContext(DbContextOptions<OneWorkDbContext> options)  : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
