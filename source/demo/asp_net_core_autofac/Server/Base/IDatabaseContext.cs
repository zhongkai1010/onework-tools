using Microsoft.EntityFrameworkCore;

namespace OneWork.Server.Base
{
    /// <summary>
    ///
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}