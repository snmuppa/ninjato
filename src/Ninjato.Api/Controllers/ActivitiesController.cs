using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ninjato.Common.Commands;
using RawRabbit;

namespace Ninjato.Api.Controllers
{
    /// <summary>
    /// Activities controller.
    /// </summary>
    [Route ("[controller]")] // route pattern matching on 'controller' name
    public class ActivitiesController : Controller 
    {
        private readonly IBusClient _busClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Api.Controllers.ActivitiesController"/> class.
        /// </summary>
        /// <param name="busClient">Bus client.</param>
        public ActivitiesController(IBusClient busClient) 
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Post the specified command.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="command">Command.</param>
        [HttpPost ("")]
        public async Task<IActionResult> Post ([FromBody] CreateActivity command) 
        {
            command.Id = Guid.NewGuid ();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync (command);

            return Accepted ($"activities/{command.Id}");
        }

        [HttpGet("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get() => Content("Secured");
    }
}