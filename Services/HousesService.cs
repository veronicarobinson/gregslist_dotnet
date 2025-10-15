
namespace gregslist_api_dotnet.Services;

public class HousesService
{

    private readonly HousesRepository _repository;

    public HousesService(HousesRepository repository)
    {
        _repository = repository;
    }

    //STUB don't forget to add scope to StartUp.cs and commit!
    internal List<House> GetHouses()
    {
        List<House> houses = _repository.GetHouses();
        return houses;
    }
}