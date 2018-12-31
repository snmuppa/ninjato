using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ninjato.Api.Handlers;
using Ninjato.Common.Authentication;
using Ninjato.Common.Events;
using Ninjato.Common.RabbitMq;

namespace Ninjato.Api
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Api.Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public Startup (IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <returns>The services.</returns>
        /// <param name="services">Services.</param>
        public IServiceProvider ConfigureServices (IServiceCollection services) 
        {
            services.AddMvc().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddConfiguration(Configuration.GetSection ("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            // let's add a handler to the events, as the API only handles the events and the services handle the commands
            services.AddScoped<IEventHandler<ActivityCreated>, ActivityCreatedHandler>();

            // Build the intermediate service provider then return it
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) 
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection ();
            app.UseMvc();
        }
    }
}