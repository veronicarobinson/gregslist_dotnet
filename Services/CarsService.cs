
namespace gregslist_api_dotnet.Services;

public class CarsService
{
  // NOTE ctrl + on property name, generate constructor
  private readonly CarsRepository _repository;

  public CarsService(CarsRepository repository)
  {
    _repository = repository;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _repository.GetCars();
    return cars;
  }
}