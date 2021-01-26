using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_web_ioc
{
    public class AppScoped  
    {
        public string Version { get; set; }

        public AppScoped()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
