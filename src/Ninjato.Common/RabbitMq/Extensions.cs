using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;

namespace Ninjato.Common.RabbitMq {
  public static class Extentions {
    public static Task WithCommandHandlerAsync<TCommand> (this IBusClient bus,
      ICommandHandler<TCommand> handler) where TCommand : ICommand => bus.SubscribeAsync<TCommand> (msg => handler.HandleAsync (msg),
      ctx => ctx.UseSubscribeConfiguration (cfg =>
        cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TCommand>()))));

    public static Task WithEventHandlerAsync<TEvent> (this IBusClient bus,
      IEventHandler<TEvent> handler) where TEvent : IEvent => bus.SubscribeAsync<TEvent> (msg => handler.HandleAsync (msg),
      ctx => ctx.UseSubscribeConfiguration (cfg =>
        cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TEvent>()))));

    private static string GetQueueName<T> () => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration) //IServiceCollection is a deafult IoC container from the ASP.NET MV Core
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