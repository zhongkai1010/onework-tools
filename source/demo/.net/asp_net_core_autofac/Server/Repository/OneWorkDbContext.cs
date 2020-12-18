using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace OneWork.Server.Repository
{
    /// <summary>
    /// </summary>
    public class OneWorkDbContext : DbContext
    {
        /// <summary>
        /// </summary>
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        /// <summary>
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=onework;Uid=root;Pwd=123qwe!@#;CharSet=utf8;");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}