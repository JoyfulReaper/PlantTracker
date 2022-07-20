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
public class PlantData
{
    public async Task Insert(Plant plant)
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "INSERT INTO Plant (Name, Location) VALUES (@Name, @Location)";
        await connection.ExecuteAsync(sql, new
        {
            Name = plant.Name,
            Location = plant.Location,
        });
    }

    public async Task<IEnumerable<Plant>> GetAll()
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "SELECT * FROM Plant";
        var plants = await connection.QueryAsync<Plant>(sql);
        
        return plants;
    }

    public async Task<Plant> Get(int plantId)
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "SELECT * FROM Plant WHERE PlantId = @PlantId";
        var plant = await connection.QuerySingleAsync<Plant>(sql, new { PlantId = plantId });

        return plant;
    }
}
