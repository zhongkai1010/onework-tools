using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_web_ioc
{
    public class AppSingleton
    {
        public string Version { get;set; }

        public AppSingleton()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
