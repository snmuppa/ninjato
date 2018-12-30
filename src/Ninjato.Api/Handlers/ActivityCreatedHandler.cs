using System;
using System.Threading.Tasks;
using Ninjato.Common.Events;

namespace Ninjato.Api.Handlers {
  public class ActivityCreatedHandler : IEventHandler<ActivityCreated> {
    public async Task HandleAsync (ActivityCreated vent) {
      await Task.CompletedTask;

      Console.WriteLine ($"Activity Created: {vent.Name}");
    }
  }
}