using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OneWork.Server.Base;
using OneWork.Server.Repository;
using System.Linq;

namespace OneWork
{
    /// <summary>
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => { options.Filters.Add<ResponseResultFilterAttribute>(); })
                .AddControllersAsServices();

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        /// <summary>
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var controllersTypesInAssembly =
                typeof(Startup)
                    .Assembly
                    .GetExportedTypes()
                    .Where(type => typeof(ControllerBase)
                        .IsAssignableFrom(type))
                    .ToArray();
            builder.RegisterType<ControllerEfTransactionInterceptor>();
            builder.RegisterTypes(controllersTypesInAssembly).EnableClassInterceptors()
                .InterceptedBy(typeof(ControllerEfTransactionInterceptor)); //∆Ù”√¿πΩÿ
            builder.RegisterType(typeof(IRepository<>));
            builder.RegisterType(typeof(BaseRepository<>));
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<OneWorkDatabaseContext>().As<IDatabaseContext>().SingleInstance();
            builder.Register(c => new OneWorkDbContext()).As<DbContext>();
        }

        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}