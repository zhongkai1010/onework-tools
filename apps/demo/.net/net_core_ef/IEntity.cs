using System;

namespace net_core_ef
{
    /// <summary>
    ///
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Guid Uuid { get; set; }
    }
}