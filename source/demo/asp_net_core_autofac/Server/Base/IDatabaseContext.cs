using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
