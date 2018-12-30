using Microsoft.AspNetCore.Mvc;

namespace Ninjato.Api.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("")]
    public IActionResult Get() => Content("Hello from Ninjato API!");
  }
}