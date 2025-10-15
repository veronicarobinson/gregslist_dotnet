namespace gregslist_api_dotnet.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
  [HttpGet("test")]
  public string Test()
  {
    return "Cars Controller is ready to roll 🛻";
  }
}