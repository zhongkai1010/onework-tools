using System;

namespace OneWork.Server.Base
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
        string Uuid { get; set; }
    }
}