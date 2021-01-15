usingystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace net_web_ioc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public classeatherForecastController : ControllerBase
    {
        privateeadonlyppSingleton _appSingleton;

        privateeadonlyppScoped _appScoped;


        privateeadonly IServiceProvider _serviceProvider;

        publiceatherForecastController(AppSingletonppSingleton,ppScopedppScoped, IServiceProvidererviceProvider)
        {
            _appSingleton =ppSingleton;
            _appScoped =ppScoped;
            _serviceProvider =erviceProvider;
        }

        [HttpGet]
        [Route("/a")]
        publictring()
        {
           eturn _appSingleton.Version;
        }

        [HttpGet]
        [Route("/b")]
        publictring()
        {
           eturn _appScoped.Version;
        }

        [HttpGet]
        [Route("/c")]
        publictring C()
        {
           ppTransientppTransient = _serviceProvider.GetService<AppTransient>();
           eturnppTransient.Version;
        }
    }
}
