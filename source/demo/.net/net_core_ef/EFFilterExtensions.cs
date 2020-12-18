using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace net_core_ef
{
    /// <summary>
    /// 
    /// </summary>
    public  static  class EfFilterExtensions
    {

        public static void SetTenantFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetTenantFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetTenantFilterMethod = typeof(EfFilterExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetTenantFilter");

        public static void SetTenantFilter<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class, ITenantEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => x.TenantId == CurrentTenant.TenantId);
        }

    }
}
