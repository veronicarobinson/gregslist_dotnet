
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

    List<Car> cars = _db.Query(
      sql,
      (Car car, Account account) =>
      {
        car.Creator = account;
        return car;
      }).ToList();

    return cars;
  }
}