using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

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

        private readonly IDatabaseContext _databaseContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="databaseContext"></param>
        public ControllerEfTransactionInterceptor(ILogger<ControllerEfTransactionInterceptor> logger, IDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
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

            IDbContextTransaction dbTransaction = _databaseContext.GetDbContext().Database.BeginTransaction();

            try
            {
                invocation.Proceed();

                _databaseContext.GetDbContext().SaveChanges();

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