
namespace gregslist_api_dotnet.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
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

    // NOTE if you have more than a single piece of data coming in on a row, you must pass Dapper a mapping function (2nd argument)
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
}