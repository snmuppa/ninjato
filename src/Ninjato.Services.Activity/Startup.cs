using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ninjato.Common.Commands;
using Ninjato.Common.Mongo;
using Ninjato.Common.RabbitMq;
using Ninjato.Services.Activity.Domain.Repositories;
using Ninjato.Services.Activity.Handlers;
using Ninjato.Services.Activity.Repositories;
using Ninjato.Services.Activity.Services;

namespace Ninjato.Services.Activity
{
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public IServiceProvider ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.AddLogging (loggingBuilder => 
            { 
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            services.AddMongoDB (Configuration);
            services.AddRabbitMq (Configuration);
            // let's add a handler to the commands, as the services handle the commands
            services.AddScoped<ICommandHandler<CreateActivity>, CreateActivityHandler> ();

            services.AddScoped<IServiceActivityRepository, ServiceActivityRepository> ();
            services.AddScoped<ICategoryRepository, CategoryRepository> ();
            services.AddScoped<IDatabaseSeeder, ActivityMongoSeeder> ();

            // Build the intermediate service provider then return it
            return services.BuildServiceProvider ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync(); // Invokes the database initializer
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}