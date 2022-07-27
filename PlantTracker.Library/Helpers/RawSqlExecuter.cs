using Dapper;
using Microsoft.Data.Sqlite;

namespace PlantTracker.Library.Services;
public class RawSqlExecuter
{
    private string _connectionString;
    public RawSqlExecuter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ExecuteSql(string sql)
    {
        using SqliteConnection connection = new SqliteConnection(_connectionString);

        try
        {
            connection.Open();
            connection.Execute(sql);
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
