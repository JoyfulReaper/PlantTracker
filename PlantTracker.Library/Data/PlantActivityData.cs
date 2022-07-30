using Dapper;
using Microsoft.Data.Sqlite;
using PlantTracker.Library.Models;
using System.Data;

namespace PlantTracker.Library.Data;
public class PlantActivityData
{
    private string _connectionString;
    public PlantActivityData(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<PlantActivity?> Get(int plantActivityId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM PlantActivity WHERE PlantActivityId = @PlantActivityId";
        var plantActivities = await connection.QuerySingleOrDefaultAsync<PlantActivity>(sql, new { PlantActivityId = plantActivityId });

        return plantActivities;
    }

    public async Task<IEnumerable<PlantActivity>> GetAll(int plantId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM PlantActivity WHERE PlantId = @PlantId";
        var plantActivities = await connection.QueryAsync<PlantActivity>(sql, new { PlantId = plantId });

        return plantActivities;
    }

    public Task Insert(PlantActivity plantActivity)
    {
        return Insert(plantActivity.PlantId, plantActivity.PlantActivityId);
    }

    public async Task Insert(int plantId, int activityId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "INSERT INTO PlantActivity (PlantId, ActivityId) VALUES (@PlantId, @ActivityId); SELECT last_insert_rowid()";
        await connection.ExecuteAsync(sql, new
        {
            PlantId = plantId,
            ActivityId = activityId,
        });
    }
}
