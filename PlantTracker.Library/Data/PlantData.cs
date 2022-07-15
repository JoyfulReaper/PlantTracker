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
    public async Task InsertPlant(Plant plant)
    {
        using IDbConnection connection = new SqliteConnection();

        string sql = "INSERT INTO Plant (Name, Location) VALUES (@Name, @Location)";
        await connection.ExecuteAsync(sql, new
        {
            Name = plant.Name,
            Location = plant.Location,
        });
    }

    public async Task<IEnumerable<Plant>> GetAll()
    {
        using IDbConnection connection = new SqliteConnection();

        string sql = "SELECT * FROM Plant";
        var plants = await connection.QueryAsync<Plant>(sql);
        
        return plants;
    }
}
