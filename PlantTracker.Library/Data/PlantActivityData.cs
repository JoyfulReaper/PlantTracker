using Dapper;
using Microsoft.Data.Sqlite;
using PlantTracker.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library.Data;
public class PlantActivityData
{
    public async Task<IEnumerable<PlantActivity>> GetAll(int plantId)
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "SELECT * FROM PlantActivity WHERE PlantId = @PlantId";
        var plantActivities = await connection.QueryAsync<PlantActivity>(sql, new { PlantId = plantId });

        return plantActivities;
    }

    public async Task AddActivity(int plantId, int activityId)
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "INSERT INTO PlantActivity (PlantId, ActivityId) VALUES (@PlantId, @ActivityId)";
        await connection.ExecuteAsync(sql, new
        {
            PlantId = plantId,
            ActivityId = activityId,
        });
    }
}
