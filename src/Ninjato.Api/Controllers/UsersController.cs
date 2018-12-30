using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ninjato.Common.Commands;
using RawRabbit;

namespace Ninjato.Api.Controllers {
  [Route("controller")]
  public class UsersController : Controller {
    private readonly IBusClient _busClient;

    public UsersController (IBusClient busClient) {
      _busClient = busClient;
    }

    [HttpPost ("register")]
    public async Task<IActionResult> Post ([FromBody] CreateUser command) {
      await _busClient.PublishAsync (command);

      return Accepted ($"users/register");
    }
  }
}