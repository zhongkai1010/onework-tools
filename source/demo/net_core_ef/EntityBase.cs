using System;

namespace net_core_ef
{
    /// <summary>
    /// 
    /// </summary>
    public  class EntityBase :IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public Guid  Uuid { get; set; } 

        public Guid? Tenant { get; set; }

    }
}
