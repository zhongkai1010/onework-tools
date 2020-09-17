using System;

namespace net_core_ef
{
    /// <summary>
    /// 
    /// </summary>
    public  interface ITenantEntity :IEntity
    {
        /// <summary>
        /// 
        /// </summary>
         Guid? TenantId { get; set; }
    }
}
