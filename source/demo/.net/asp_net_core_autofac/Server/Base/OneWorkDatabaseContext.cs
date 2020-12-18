using Microsoft.EntityFrameworkCore;

namespace OneWork.Server.Base
{
    /// <summary>
    ///
    /// </summary>
    public class OneWorkDatabaseContext : IDatabaseContext
    {
        /// <summary>
        ///
        /// </summary>
        private readonly DbContext _dbContext;

        /// <summary>
        ///
        /// </summary>
        /// <param name="dbContext"></param>
        public OneWorkDatabaseContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}