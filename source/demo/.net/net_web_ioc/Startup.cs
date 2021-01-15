using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
usingystem;
usingystem.Collections.Generic;
usingystem.Linq;
usingystem.Threading.Tasks;

namespace net_web_ioc
{
    public classtartup
    {
        publictartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets calledy theuntime. Use this method toddervices to the container.
        public void ConfigureServices(IServiceCollectionervices)
        {
           ervices.AddControllers();

           ervices.AddSingleton<AppSingleton>();

           ervices.AddScoped<AppScoped>();

           ervices.AddTransient<AppTransient>();
        }

        // This method gets calledy theuntime. Use this method to configure the HTTPequest pipeline.
        public void Configure(IApplicationBuilderpp, IWebHostEnvironmentnv)
        {
            ifenv.IsDevelopment())
            {
               pp.UseDeveloperExceptionPage();
            }

           pp.UseRouting();

           pp.UseAuthorization();

           pp.UseEndpoints(endpoints =>
            {
               ndpoints.MapControllers();
            });
        }
    }
}
