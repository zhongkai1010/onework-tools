using System;

namespace net_core_ef
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityBase : ITenantEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid Uuid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? TenantId { get; set; }

    }
}
