using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ninjato.Common.Commands;
using Ninjato.Common.Services;

namespace Ninjato.Services.Activity {
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