using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;

namespace Ninjato.Common.RabbitMq 
{
    /// <summary>
    /// Extentions for RabbitMq driver.
    /// </summary>
    public static class Extentions 
    {
        /// <summary>
        /// Withs the command handler async.
        /// </summary>
        /// <returns>The command handler async.</returns>
        /// <param name="bus">Bus.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TCommand">The 1st type parameter.</typeparam>
        public static Task WithCommandHandlerAsync<TCommand> (this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand => bus.SubscribeAsync<TCommand> (msg => handler.HandleAsync (msg),
            ctx => ctx.UseSubscribeConfiguration (cfg =>
            cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TCommand>()))));

        /// <summary>
        /// Withs the event handler async.
        /// </summary>
        /// <returns>The event handler async.</returns>
        /// <param name="bus">Bus.</param>
        /// <param name="handler">Handler.</param>
        /// <typeparam name="TEvent">The 1st type parameter.</typeparam>
        public static Task WithEventHandlerAsync<TEvent> (this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent => bus.SubscribeAsync<TEvent> (msg => handler.HandleAsync (msg),
            ctx => ctx.UseSubscribeConfiguration (cfg =>
            cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TEvent>()))));

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        /// <returns>The queue name.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private static string GetQueueName<T> () => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        /// <summary>
        /// Adds the rabbit mq.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) // IServiceCollection is a deafult IoC container from the ASP.NET MV Core
        {
            var options = new RabbitmqOptions();
            var section = configuration.GetSection("RabbitMq"); // gets the RabbitMq section from the appSettings.json
            section.Bind(options);

            // the following create the Bus client
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            { 
                ClientConfiguration = options
            });

            services.AddSingleton<IBusClient>(_ => client); // this is a singleton as we want the RawRabbit libraryb to manage to the connections to the Bus
        }
    }
}