using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using Ninjato.Common.Exceptions;
using Ninjato.Services.Identity.Services;
using RawRabbit;

namespace Ninjato.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;

        private readonly IUserService _userService;

        private ILogger _logger; // custom logger

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Identity.Handlers.CreateUserHandler"/> class.
        /// </summary>
        /// <param name="busClient">Bus client.</param>
        /// <param name="userService">User service.</param>
        /// <param name="logger">Logger.</param>
        public CreateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUser> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Handles the commands of type <see cref="T:Ninjato.Common.Commands.CreateUser"/> asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="command">Command.</param>
        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating user: '{command.Email}' with name '{command.Name}'");

            try
            {
                await _userService.RegisterAsync(command.Email, command.Password, command.Name);

                // producing an event - if the Add Activity succeeds
                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));

                _logger.LogInformation($"User: '{command.Email}' was created with name: '{command.Name}'.");

                return;
            }
            catch (NinjatoException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, ex.Code, ex.Message));

                _logger.LogError(ex.Message);
            }
            catch (Exception ex) // handling a more generic exception
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "Generic Error", ex.Message));

                _logger.LogError(ex.Message);
            }
        }
    }
}
