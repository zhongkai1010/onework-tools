using OneWork.Server.Base;

namespace OneWork.Server.Repository
{
    /// <summary>
    ///
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="databaseContext"></param>
        public UserRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}