using System;

namespace OneWork.Server.Base
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

        /// <summary>
        /// 
        /// </summary>
        public string Uuid { get; set; }
    }
}
