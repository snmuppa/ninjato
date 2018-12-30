using Ninjato.Common.Commands;
using Ninjato.Common.Services;

namespace Ninjato.Services.Activity
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program 
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main (string[] args) 
        {
            ServiceHost.Create<Startup> (args)
                .UseRabbitMq ()
                .SubscribeToCommand<CreateActivity> ()
                .Build ()
                .Run ();
        }
    }
}