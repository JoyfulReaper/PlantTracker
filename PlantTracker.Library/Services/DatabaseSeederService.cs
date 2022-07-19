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
    public void SeedDatabase(string sql)
    {
        using SqliteConnection connection = new SqliteConnection(StaticConfiguration.ConnectionString);

        try
        {
            connection.Open();
            connection.Execute(sql);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
