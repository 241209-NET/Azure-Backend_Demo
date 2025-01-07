using Microsoft.AspNetCore.Mvc;

namespace PetTracker.API.Controller;

[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{    
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}