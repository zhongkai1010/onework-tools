usingystem;
usingystem.Collections.Generic;
usingystem.Linq;
usingystem.Threading.Tasks;

namespace net_web_ioc
{
    public classppSingleton
    {
        publictring Version { get;et; }

        publicppSingleton()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
