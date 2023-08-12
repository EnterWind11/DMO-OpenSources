using Npgsql;
using System.Collections.Generic;

namespace Yggdrasil.Database;

public class PostgreSqlQuery : IQuery<List<Dictionary<string, object>>>
{
    private readonly string _connectionString;

    public PostgreSqlQuery()
    {
        _connectionString = "Host=192.168.0.34;Username=dmo;Password=Tb6!kV7-yM!z7FS#BevB;Database=dmo";
    }

    public List<Dictionary<string, object>> Execute(string sqlQuery)
    {
        var results = new List<Dictionary<string, object>>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sqlQuery, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    results.Add(row);
                }
            }
        }

        return results;
    }
    public void Execute(string sqlQuery, Dictionary<string, object> parameters = null)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sqlQuery, connection))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }

                command.ExecuteNonQuery();
            }
        }
    }
}