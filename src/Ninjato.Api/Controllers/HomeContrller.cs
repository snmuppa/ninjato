using Microsoft.AspNetCore.Mvc;

namespace Ninjato.Api.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Ninjato API!");
    }
}