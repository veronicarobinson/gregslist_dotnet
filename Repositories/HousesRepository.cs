

namespace gregslist_api_dotnet.Repositories;

public class HousesRepository
{
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    //STUB don't forget to add scope to StartUp.cs and commit!

    internal List<House> GetHouses()
    {
        string sql = @"
        SELECT 
            houses.*,
            accounts.*
        FROM
            houses
        INNER JOIN accounts ON houses.creator_id = accounts.id
        ORDER BY houses.id;
        ";


        //NOTE if you have more than one single piece of data coming in on a row (JOIN), you must pass Dapper (a mapping function - 2nd argument)
        //Dapper will map the rows of data into the supplied parameters of the mapping function in the order that they appear on each row. Dapper will assume it is seeing a new data type every time it encournters an id column. 
        List<House> houses = _db.Query(
            sql,
            // STUB make sure that the Data coming in and out is in the same order here (below)          
            (House house, Profile account) =>
            {
                house.Creator = account; //and here
                return house;
            }).ToList();

        return houses;

    }
}