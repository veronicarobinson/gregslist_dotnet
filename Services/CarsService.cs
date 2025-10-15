

namespace gregslist_api_dotnet.Services;

public class CarsService
{
  // NOTE ctrl + on property name, generate constructor
  private readonly CarsRepository _repository;

  public CarsService(CarsRepository repository)
  {
    _repository = repository;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repository.CreateCar(carData);
    return car;
  }

  internal string DeleteCar(int carId, Account userInfo)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU CANNOT DELETE A CAR THAT YOU DID NOT CREATE, {userInfo.Name.ToUpper()}!!!");
    }

    _repository.DeleteCar(carId);

    return $"Successfully deleted your {car.Make} {car.Model}!";
  }

  internal Car GetCarById(int carId)
  {
    Car car = _repository.GetCarById(carId);

    if (car == null)
    {
      throw new Exception("No car found with the id of: " + carId);
    }

    return car;
  }

  internal List<Car> GetCars()
  {
    List<Car> cars = _repository.GetCars();
    return cars;
  }
}