using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace net_core_ef
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
            optionsBuilder.UseMySql("Server=127.0.0.1;Database=net_core_ef;Uid=root;Pwd=123qwe!@#;CharSet=utf8;");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        /// <summary>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mutableEntityTypes = modelBuilder.Model.GetEntityTypes();
            foreach (var type in mutableEntityTypes)
            {
                if (typeof(ITenantEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetTenantFilter(type.ClrType);
            }
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entityEntry in entities)
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        if (entityEntry.Entity is IEntity)
                        {
                            var propertyInfo = entityEntry.Property("Uuid").Metadata.PropertyInfo;
                            propertyInfo.SetValue(entityEntry.Entity, Guid.NewGuid());
                        }

                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Modified:
                        break;
                }

            return base.SaveChanges();
        }
    }
}