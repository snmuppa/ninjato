using System;
using System.Threading.Tasks;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using RawRabbit;

namespace Ninjato.Services.Activity.Handlers {
  public class CreateActivityHandler : ICommandHandler<CreateActivity> {

    private readonly IBusClient _busClient;

    public CreateActivityHandler (IBusClient busClient) 
    {
      _busClient = busClient;
    }
    public async Task HandleAsync (CreateActivity command) 
    {
      Console.WriteLine($"Creating activity: {command.Name}");
      // producing an event
      await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, 
        command.Name, command.Description, command.CreatedAt));
    }
  }
}