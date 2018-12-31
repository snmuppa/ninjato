using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ninjato.Common.Commands;
using Ninjato.Services.Identity.Services;

namespace Ninjato.Services.Identity.Controllers
{
    /// <summary>
    /// Account controller.
    /// </summary>
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Identity.Controllers.AccountController"/> class.
        /// </summary>
        /// <param name="userService">User service.</param>
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login the specified command.
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="command">Command.</param>
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
            => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
