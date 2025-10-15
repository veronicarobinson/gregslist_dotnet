namespace gregslist_api_dotnet.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;
  private readonly Auth0Provider _auth;

  public CarsController(CarsService carsService, Auth0Provider auth0Provider)
  {
    _carsService = carsService;
    _auth = auth0Provider;
  }

  [HttpGet("test")]
  public string Test()
  {
    return "Cars Controller is ready to roll 🛻";
  }

  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPost]
  [Authorize] // You must be logged in to run the following method!

  public async Task<ActionResult<Car>> CreateCar([FromBody] Car carData)
  {
    try
    {
      // NOTE httpcontext has our bearer token on it
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      // assigns ownership to data based on who is logged in
      carData.CreatorId = userInfo.Id;
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}