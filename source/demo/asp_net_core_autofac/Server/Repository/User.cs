using OneWork.Server.Base;
using System;

namespace OneWork.Server.Repository
{
    /// <summary>
    ///
    /// </summary>
    public class User : IEntity
    {
        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }
    }
}