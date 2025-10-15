namespace gregslist_api_dotnet.Controllers;

[ApiController]
[Route("api/houses")]

public class HousesController : ControllerBase
{
    private readonly HousesService _housesService;
    private readonly Auth0Provider _auth;

    public HousesController(HousesService housesService, Auth0Provider auth)
    {
        _housesService = housesService;
        _auth = auth;
    }


    [HttpGet]

    public ActionResult<List<House>> GetHouses()
    {
        try
        {
            List<House> houses = _housesService.GetHouses();
            return Ok(houses);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }




}

