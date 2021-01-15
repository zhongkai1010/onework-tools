using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
usingystem;
usingystem.Collections.Generic;
usingystem.Linq;
usingystem.Threading.Tasks;

namespace net_web_ioc
{
    public class Program
    {
        publictatic void Main(string[]rgs)
        {
            CreateHostBuilder(args).Build().Run();
        }

        publictatic IHostBuilder CreateHostBuilder(string[]rgs) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                   ebBuilder.UseStartup<Startup>();
                });
    }
}
