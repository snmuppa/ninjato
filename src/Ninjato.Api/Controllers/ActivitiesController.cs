using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ninjato.Common.Commands;
using RawRabbit;

namespace Ninjato.Api.Controllers {
  [Route ("[controller]")] // route pattern matching on 'controller' name
  public class ActivitiesController : Controller {
    private readonly IBusClient _busClient;

    public ActivitiesController(IBusClient busClient) {
      _busClient = busClient;
    }

    [HttpPost ("")]
    public async Task<IActionResult> Post ([FromBody] CreateActivity command) {
      command.Id = Guid.NewGuid ();
      command.CreatedAt = DateTime.UtcNow;
      await _busClient.PublishAsync (command);

      return Accepted ($"activities/{command.Id}");
    }
  }
}