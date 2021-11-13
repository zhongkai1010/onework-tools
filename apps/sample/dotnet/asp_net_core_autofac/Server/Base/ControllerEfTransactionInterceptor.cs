using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace OneWork.Server.Base
{
    /// <summary>
    ///
    /// </summary>
    public class ControllerEfTransactionInterceptor : IInterceptor
    {
        /// <summary>
        ///
        /// </summary>
        private readonly ILogger<ControllerEfTransactionInterceptor> _logger;

        private readonly DbContext _dbContext;

        /// <summary>
        ///
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="databaseContext"></param>
        public ControllerEfTransactionInterceptor(ILogger<ControllerEfTransactionInterceptor> logger, IDatabaseContext databaseContext)
        {
            _logger = logger;
            _dbContext = databaseContext.GetDbContext();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            _logger.LogWarning("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            IDbContextTransaction dbTransaction = _dbContext.Database.BeginTransaction();

            try
            {
                invocation.Proceed();

                _dbContext.SaveChanges();

                dbTransaction.Commit();
            }
            catch (Exception)
            {
                dbTransaction.Rollback();
                throw;
            }

            _logger.LogWarning("Done: result was {0}.", invocation.ReturnValue);
        }
    }
}