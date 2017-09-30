using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MyLondonUnderground.Application.CommandHandlers;
using MyLondonUnderground.Domain.Model;
using MyLondonUnderground.Infrastructure.EntityFramework;
using MyLondonUnderground.QueryStack.Implementations;
using StructureMap;
using MyLondonUnderground.Application.Scaffolding;
using FluentValidation;

namespace MyLondonUnderground.Admin
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScaffoldingContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            return ConfigureIoc(services);
        }

        public IServiceProvider ConfigureIoc(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.AssemblyContainingType(typeof(TubeLine));
                    _.AssemblyContainingType(typeof(AddNewTubeLineCommandHandler));
                    _.AssemblyContainingType(typeof(LondonUndergroundContext));
                    _.AssemblyContainingType(typeof(LondonUndergroundDbReaderService));
                    _.WithDefaultConventions();

                    _.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>)); // Handlers with no response
                    _.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); // Handlers with a response
                    _.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>)); // Async handlers with no response
                    _.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>)); // Async Handlers with a response
                    _.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    _.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));

                    _.ConnectImplementationsToTypesClosing(typeof(AbstractValidator<>));

                    //_.AddAllTypesOf<IGamingService>();
                    //_.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                });
                //config.For<IEmailSender>().Use<AuthMessageSender>().Transient();
                //config.For<ISmsSender>().Use<AuthMessageSender>().Transient();



                //Populate the container using the service collection
                config.Populate(services);

                config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
                config.For<IMediator>().Use<Mediator>();

            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
