usingystem;
usingystem.Collections.Generic;
usingystem.Linq;
usingystem.Threading.Tasks;

namespace net_web_ioc
{
    public classppTransient
    {

        publictring Version { get;et; }

        publicppTransient()
        {
            Version = DateTime.Now.ToLongTimeString();
        }
    }
}
