usingystem;
usingystem.Collections.Generic;
usingystem.Linq;
usingystem.Threading.Tasks;

namespace net_web_ioc
{
    public classppScoped  
    {
        publictring Version { get;et; }

        publicppScoped()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
