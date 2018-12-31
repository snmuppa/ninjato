using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using Ninjato.Common.Exceptions;
using Ninjato.Services.Activity.Services;
using RawRabbit;

namespace Ninjato.Services.Activity.Handlers
{
    /// <summary>
    /// Create activity handler.
    /// </summary>
    public class CreateActivityHandler : ICommandHandler<CreateActivity> 
    {
        private readonly IBusClient _busClient;

        private readonly IActivityService _activityService;

        private ILogger _logger; // custom logger

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Handlers.CreateActivityHandler"/> class.
        /// </summary>
        /// <param name="busClient">Bus client.</param>
        /// <param name="activityService">Activity service.</param>
        /// <param name="logger">Logger.</param>
        public CreateActivityHandler (IBusClient busClient, IActivityService activityService, ILogger<CreateActivityHandler> logger) 
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        /// <summary>
        /// Handles the commands of type <see cref="T:Ninjato.Common.Commands.CreateActivity"/> asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="command">Command.</param>
        public async Task HandleAsync (CreateActivity command) 
        {
            _logger.LogInformation($"Creating activity: {command.Name}");

            try 
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, 
                    command.Name, command.Description, command.CreatedAt);

                // producing an event - if the Add Activity succeeds
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
                    command.Name, command.Description, command.CreatedAt));

                return;
            } 
            catch(NinjatoException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch(Exception ex) // handling a more generic exception
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "Generic Error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}