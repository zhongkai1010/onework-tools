using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=onework;Uid=root;Pwd=123QWE!@#;");
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            base.OnModelCreating(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
