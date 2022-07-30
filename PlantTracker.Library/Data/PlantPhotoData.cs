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
public class PlantPhotoData
{
    private string _connectionString;

    public PlantPhotoData(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task Insert(PlantPhoto plantPhoto)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "INSERT INTO PlantPhoto (PlantId, Photo, PhotoContentType) VALUES (@PlantId, @Photo, @PhotoContentType); SELECT last_insert_rowid()";
        var id = await connection.QuerySingleAsync<int>(sql, new
        {
            PlantId = plantPhoto.PlantId,
            Photo = plantPhoto.Photo,
            PhotoContentType = plantPhoto.PhotoContentType,
        });

        plantPhoto.PlantPhotoId = id;
    }

    public async Task<PlantPhoto> GetPlantPhoto(int plantId)
    {
        using IDbConnection connection = new SqliteConnection(_connectionString);

        string sql = "SELECT * FROM PlantPhoto WHERE PlantId = @PlantId";
        var plantPhoto = await connection.QuerySingleAsync<PlantPhoto>(sql, new { PlantId = plantId });

        return plantPhoto;
    }
}
