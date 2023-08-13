using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace Yggdrasil.Database
{
    public class BaseDB
    {
        private static NpgsqlConnection m_con;

        private readonly string _connectionString = "Host=192.168.0.34;Username=dmo;Password=Tb6!kV7-yM!z7FS#BevB;Database=dmo";

        public NpgsqlConnection GetNewConnection()
        {
            Connection = Connect();
            return Connection;
        }

        public NpgsqlConnection Connection
        {
            get
            {
                if (m_con == null || m_con.State != ConnectionState.Open || m_con.Database == "")
                    m_con = Connect();
                return m_con;
            }
            set { m_con = value; }
        }

        public BaseDB()
        {
            Connection = Connect();
        }

        public NpgsqlConnection Connect()
        {
            return Connect(_connectionString);
        }

        public NpgsqlConnection Connect(string connectionString)
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (NpgsqlException)
            {
                return null;
            }
        }

        public void Execute(string query, params object[] args)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(string.Format(query, args), Connection);
            cmd.ExecuteNonQuery();
        }

        public List<Dictionary<string, object>> Query(string query, Dictionary<string, object> parameters = null)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(query, Connection);

            // Adiciona os parâmetros ao comando, se houver
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader.GetValue(i));
                }
                rows.Add(row);
            }
            reader.Close();

            return rows;
        }

        public interface IQuery<T>
        {
            T Execute(string sqlQuery);
        }

        public interface ICommand
        {
            void Execute(string sqlQuery, Dictionary<string, object> parameters = null);
        }

        public class MyQuery : IQuery<List<Dictionary<string, object>>>
        {
            private readonly BaseDB _db;

            public MyQuery(BaseDB db)
            {
                _db = db;
            }

            public List<Dictionary<string, object>> Execute(string sqlQuery)
            {
                return _db.Query(sqlQuery);
            }
        }

        public class MyCommand : ICommand
        {
            private readonly BaseDB _db;

            public MyCommand(BaseDB db)
            {
                _db = db;
            }

            public void Execute(string sqlQuery, Dictionary<string, object> parameters = null)
            {
                _db.Execute(sqlQuery, parameters);
            }
        }

    }
}
