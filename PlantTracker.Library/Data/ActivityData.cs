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
public class ActivityData
{
    public async Task<IEnumerable<Activity>> GetAll()
    {
        using IDbConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        string sql = "SELECT * FROM Activity";
        var activities = await connection.QueryAsync<Activity>(sql);

        return activities;
    }
}
