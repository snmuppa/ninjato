using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ninjato.Common.Commands;
using RawRabbit;

namespace Ninjato.Api.Controllers
{
    /// <summary>
    /// Users controller.
    /// </summary>
    [Route("[controller]")]
    public class UsersController : Controller 
    {
        private readonly IBusClient _busClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Api.Controllers.UsersController"/> class.
        /// </summary>
        /// <param name="busClient">Bus client.</param>
        public UsersController (IBusClient busClient) 
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Post the specified command.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="command">Command.</param>
        [HttpPost ("register")]
        public async Task<IActionResult> Post([FromBody] CreateUser command) 
        {
            await _busClient.PublishAsync (command);

            return Accepted ($"users/register");
        }
    }
}