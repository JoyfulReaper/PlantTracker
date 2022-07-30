using Dapper;
using Microsoft.Data.Sqlite;
using PlantTracker.Library.Models;
using System.Data;

namespace PlantTracker.Library.Data;
public class PlantData
{
    private string _connectionString;

    public PlantData(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task Insert(Plant plant)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "INSERT INTO Plant (Name, Location, PlantPhotoId) VALUES (@Name, @Location, @PlantPhotoId); SELECT last_insert_rowid()";
        var id = await connection.QuerySingleAsync<int>(sql, new
        {
            Name = plant.Name,
            Location = plant.Location,
            PlantPhotoId = plant.PlantPhotoId
        });

        plant.PlantId = id;
    }

    public async Task Update(Plant plant)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "UPDATE Plant SET Name = @Name, Location = @Location, PlantPhotoId = @PlantPhotoId WHERE PlantId = @PlantId";
        await connection.ExecuteAsync(sql, new
        {
            Name = plant.Name,
            Location = plant.Location,
            PlantPhotoId = plant.PlantPhotoId,
            PlantId = plant.PlantId
        });
    }
    
    public async Task<IEnumerable<Plant>> GetAll()
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM Plant";
        var plants = await connection.QueryAsync<Plant>(sql);
        
        return plants;
    }

    public async Task<Plant> Get(int plantId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM Plant WHERE PlantId = @PlantId";
        var plant = await connection.QuerySingleAsync<Plant>(sql, new { PlantId = plantId });

        return plant;
    }
}
