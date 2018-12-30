using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using Ninjato.Common.RabbitMq;
using RawRabbit;

namespace Ninjato.Common.Services
{
    /// <summary>
    /// Service host.
    /// </summary>
    public class ServiceHost : IServiceHost 
    {
        private readonly IWebHost _webHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Services.ServiceHost"/> class.
        /// </summary>
        /// <param name="webHost">Web host.</param>
        public ServiceHost (IWebHost webHost) 
        {
            _webHost = webHost;
        }

        /// <summary>
        /// Run this instance.
        /// </summary>
        public void Run () => _webHost.Run ();

        /// <summary>
        /// Create the specified args.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="args">Arguments.</param>
        /// <typeparam name="TStartup">The 1st type parameter.</typeparam>
        public static HostBuilder Create<TStartup> (string[] args) where TStartup : class 
        {
            Console.Title = typeof (TStartup).Namespace;
            var config = new ConfigurationBuilder ()
            .AddEnvironmentVariables ()
            .AddCommandLine (args)
            .Build ();

            var webHostBuilder = WebHost.CreateDefaultBuilder (args)
            .UseConfiguration (config)
            .UseStartup<TStartup> ();

            return new HostBuilder (webHostBuilder.Build ());
        }

        /// <summary>
        /// Builder base.
        /// </summary>
        public abstract class BuilderBase 
        {
            /// <summary>
            /// Build this instance.
            /// </summary>
            /// <returns>The build.</returns>
            public abstract ServiceHost Build ();
        }

        /// <summary>
        /// Host builder.
        /// </summary>
        public class HostBuilder : BuilderBase 
        {
            private readonly IWebHost _webHost;

            private IBusClient _bus;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Ninjato.Common.Services.ServiceHost.HostBuilder"/> class.
            /// </summary>
            /// <param name="webHost">Web host.</param>
            public HostBuilder (IWebHost webHost) 
            {
                _webHost = webHost;
            }

            /// <summary>
            /// Uses the rabbit mq.
            /// </summary>
            /// <returns>The rabbit mq.</returns>
            public BusBuilder UseRabbitMq () 
            {
                _bus = (IBusClient) _webHost.Services.GetService (typeof (IBusClient));
                return new BusBuilder (_webHost, _bus);
            }

            /// <summary>
            /// Build this instance.
            /// </summary>
            /// <returns>The build.</returns>
            public override ServiceHost Build () 
            {
                return new ServiceHost (_webHost);
            }
        }

        /// <summary>
        /// Bus builder.
        /// </summary>
        public class BusBuilder : BuilderBase 
        {
            private readonly IWebHost _webHost;

            private IBusClient _bus;

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Ninjato.Common.Services.ServiceHost.BusBuilder"/> class.
            /// </summary>
            /// <param name="webHost">Web host.</param>
            /// <param name="bus">Bus.</param>
            public BusBuilder (IWebHost webHost, IBusClient bus) 
            {
                _webHost = webHost;
                _bus = bus;
            }

            /// <summary>
            /// Subscribes to command.
            /// </summary>
            /// <returns>The to command.</returns>
            /// <typeparam name="TCommand">The 1st type parameter.</typeparam>
            public BusBuilder SubscribeToCommand<TCommand> () where TCommand : ICommand 
            {
                var handler = (ICommandHandler<TCommand>) _webHost.Services.GetService (typeof(ICommandHandler<TCommand>));
                _bus.WithCommandHandlerAsync(handler);

                return this;
            }

            /// <summary>
            /// Subscribes to event.
            /// </summary>
            /// <returns>The to event.</returns>
            /// <typeparam name="TEvent">The 1st type parameter.</typeparam>
            public BusBuilder SubscribeToEvent<TEvent> () where TEvent : IEvent 
            {
                var handler = (IEventHandler<TEvent>) _webHost.Services.GetService (typeof(IEventHandler<TEvent>));
                _bus.WithEventHandlerAsync(handler);

                return this;
            }

            /// <summary>
            /// Build this instance.
            /// </summary>
            /// <returns>The build.</returns>
            public override ServiceHost Build () 
            {
                return new ServiceHost (_webHost);
            }
        }
    }
}