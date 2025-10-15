

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

  internal Car UpdateCar(int carId, Car carData, Account userInfo)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU CANNOT ALTER SOMEONE ELSE'S DATA YOU BIG STUPID IDIOT. I AM GIVING YOUR EMAIL TO THE AUTHORITIES. YOUR EMAIL IS {userInfo.Email}. I HAVE IT AND YOU ARE IN BIG TROUBLE, BUSTER");
    }

    car.Make = carData.Make ?? car.Make;
    car.Model = carData.Model ?? car.Model;
    car.Color = carData.Color ?? car.Color;
    // NOTE property must be nullable in model for this check to work
    car.Year = carData.Year ?? car.Year;
    car.Mileage = carData.Mileage ?? car.Mileage;
    car.ImgUrl = carData.ImgUrl ?? car.ImgUrl;
    // NOTE property must be nullable in model for this check to work
    car.HasCleanTitle = carData.HasCleanTitle ?? car.HasCleanTitle;
    car.EngineType = carData.EngineType ?? car.EngineType;
    car.Description = carData.Description ?? carData.Description;

    _repository.UpdateCar(car);

    return car;
  }
}