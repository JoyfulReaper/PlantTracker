using Dapper;
using Microsoft.Data.Sqlite;
using PlantTracker.Library.Models;
using System.Data;


namespace PlantTracker.Library.Data;
public class ActivityData
{
    private string _connectionString;
    public ActivityData(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<Activity?> Get(int activityId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM Activity WHERE ActivityId = @ActivityId";
        return await connection.QuerySingleOrDefaultAsync<Activity>(sql, new {ActivityId = activityId});
    }

    public async Task<Activity?> Get(string name)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM Activity WHERE Name = @Name";
        return await connection.QuerySingleOrDefaultAsync<Activity>(sql, new {Name = name});
    }

    public async Task<IEnumerable<Activity>> GetAll()
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM Activity";
        var activities = await connection.QueryAsync<Activity>(sql);

        return activities;
    }
}
