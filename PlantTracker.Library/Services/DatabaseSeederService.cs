using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker.Library.Services;
public class DatabaseSeederService
{
    public async Task SeedDatabase(string sql)
    {
        using IDbConnection connection = new SqliteConnection();

        await connection.ExecuteAsync(sql);
    }
}
