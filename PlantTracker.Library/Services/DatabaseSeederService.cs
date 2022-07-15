using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlantTracker.Library.Services;
public class DatabaseSeederService
{
    public async Task SeedDatabase(string sql)
{
        var test = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PlantTracker.db"); 
        using SqliteConnection connection = new SqliteConnection("Data source="+test+";");

        try
        {
            connection.Open();
            await connection.ExecuteAsync(sql);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
