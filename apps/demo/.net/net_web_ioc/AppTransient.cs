using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_web_ioc
{
    public class AppTransient
    {

        public string Version { get;set; }

        public AppTransient()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
