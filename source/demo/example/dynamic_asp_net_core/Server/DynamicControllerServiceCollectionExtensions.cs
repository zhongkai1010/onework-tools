using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace dynamic_asp_net_core.Server
{
    public static  class DynamicControllerServiceCollectionExtensions
    {

        public static IServiceCollection AddDynamicControllers(this IServiceCollection services)
        {

            ApplicationPartManager partManager = services.GetSingletonInstanceOrNull<ApplicationPartManager>();

            partManager.FeatureProviders.Add(new DynamicWebApiControllerFeatureProvider());

            services.Configure<MvcOptions>(options => { options.Conventions.Add(new DynamicWebApiConvention()); });

            return services;
        }

        public static T GetSingletonInstanceOrNull<T>(this IServiceCollection services)
        {
            return (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
        }
    }

    public class DynamicWebApiControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            return typeInfo.IsClass && typeInfo.IsPublic && typeInfo == typeof(UserApplication);
        }
    }
}
