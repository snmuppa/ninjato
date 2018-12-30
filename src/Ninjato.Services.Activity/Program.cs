using Ninjato.Common.Commands;
using Ninjato.Common.Services;

namespace Ninjato.Services.Activity
{
    public class Program {
        public static void Main (string[] args) {
            ServiceHost.Create<Startup> (args)
                .UseRabbitMq ()
                .SubscribeToCommand<CreateActivity> ()
                .Build ()
                .Run ();
        }
    }
}