



namespace gregslist_api_dotnet.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO
      cars 
      (
      make,
      model,
      `year`,
      price,
      img_url,
      description,
      engine_type,
      color,
      mileage,
      has_clean_title,
      creator_id
      )
    VALUES
      (
      @Make,
      @Model,
      @Year,
      @Price,
      @ImgUrl,
      @Description,
      @EngineType,
      @Color,
      @Mileage,
      @HasCleanTitle,
      @CreatorId
      );
      
      SELECT
        cars.*,
        accounts.*
      FROM cars
      JOIN accounts ON cars.creator_id = accounts.id
      WHERE cars.id = LAST_INSERT_ID();";

    Car car = _db.Query(
      sql,
      (Car car, Profile account) =>
      {
        car.Creator = account;
        return car;
      },
      carData).SingleOrDefault();

    return car;
  }

  internal void DeleteCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @CarId LIMIT 1;";

    object param = new { CarId = carId };

    int rowsAffected = _db.Execute(sql, param);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows of data are now gone and that is not good!");
    }
  }

  internal Car GetCarById(int carId)
  {
    string sql = @"
    SELECT
      cars.*,
      accounts.*
    FROM
      cars
    JOIN accounts ON accounts.id = cars.creator_id
    WHERE cars.id = @CarId;";

    object param = new { CarId = carId };

    Car car = _db.Query(
      sql,
      (Car car, Profile account) =>
      {
        car.Creator = account;
        return car;
      },
      param).SingleOrDefault();

    return car;
  }

  internal List<Car> GetCars()
  {
    string sql = @"
    SELECT
      cars.*,
      accounts.*
    FROM
      cars
    INNER JOIN accounts ON cars.creator_id = accounts.id
    ORDER BY cars.id;";

    // NOTE if you have more than a single piece of data coming in on a row (JOIN statement), you must pass Dapper a mapping function (2nd argument)
    // Dapper will map the rows of data into the supplied parameters of the mapping function in the order that they appear on each row. Dapper will assume it is seeing a new data type every time it encounters an id column
    List<Car> cars = _db.Query(
      sql,
      (Car car, Profile account) =>
      {
        car.Creator = account;
        return car;
      }).ToList();

    return cars;
  }

  internal void UpdateCar(Car carData)
  {
    string sql = @"
    UPDATE cars
    SET
    make = @Make,
    model = @Model,
    year = @Year,
    price = @Price,
    color = @Color,
    img_url = @ImgUrl,
    mileage = @Mileage,
    engine_type = @EngineType,
    has_clean_title = @HasCleanTitle,
    description = @Description
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, carData);

    if (rowsAffected != 1)
    {
      throw new Exception(rowsAffected + " rows of data are now updated and that is not good!");
    }
  }
}