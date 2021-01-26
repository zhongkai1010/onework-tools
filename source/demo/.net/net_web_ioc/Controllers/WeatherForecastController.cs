using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace net_web_ioc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppSingleton _appSingleton;

        private readonly AppScoped _appScoped;


        private readonly IServiceProvider _serviceProvider;

        public WeatherForecastController(AppSingleton appSingleton, AppScoped appScoped, IServiceProvider serviceProvider)
        {
            _appSingleton = appSingleton;
            _appScoped = appScoped;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        [Route("/a")]
        public string A()
        {
            return _appSingleton.Version;
        }

        [HttpGet]
        [Route("/b")]
        public string B()
        {
            return _appScoped.Version;
        }

        [HttpGet]
        [Route("/c")]
        public string C()
        {
            AppTransient appTransient = _serviceProvider.GetService<AppTransient>();
            return appTransient.Version;
        }
    }
}
