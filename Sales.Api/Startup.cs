using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalesRepository.Context;
using SalesRepository.Repositories;
using SalesRepository.Repositories.Interfaces;
using SalesServices.Mapping;
using SalesServices.Products;
using SalesServices.Products.Interfaces;

namespace Sales.Api
{
    public class Startup
    {
        readonly string SalesOrigin = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(SalesOrigin,
                build =>
                {
                    build.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Create the container builder.
            var builder = new ContainerBuilder();
            builder.Populate(services);

            DependencyConfigurtion(builder);

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void DependencyConfigurtion(ContainerBuilder builder)
        {
            var configuration = new MapperConfiguration(cfg =>
                            cfg.AddMaps(new[] {
                                typeof(ProductMapping)
                            })
            );

            builder.RegisterType<Mapper>()
                .As<IMapper>()
                .WithParameter("configurationProvider", configuration); ;

            builder.RegisterType<RepositoryContext>()
                    .WithParameter("connection", Effort.DbConnectionFactory.CreateTransient());

            builder.RegisterAssemblyTypes(Assembly.Load("SalesRepository"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("SalesServices"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            ApplicationContainer = builder.Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(SalesOrigin);

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
