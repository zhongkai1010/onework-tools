using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace OneWork.Server.Base
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        ///
        /// </summary>
        protected DbContext DbContext;

        /// <summary>
        ///
        /// </summary>
        /// <param name="databaseContext"></param>
        public BaseRepository(IDatabaseContext databaseContext)
        {
            DbContext = databaseContext.GetDbContext();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            entity.Uuid = Guid.NewGuid().ToString();
            DbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            DbContext.Attach(entity);
            DbContext.Update(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            DbContext.Attach(entity);
            DbContext.Remove(entity);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetQueryable()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }
    }
}