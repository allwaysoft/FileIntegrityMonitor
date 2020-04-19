using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FileIntegrityMonitor.DAL
{
    public class DALBase<T>
    {
        public List<T> SelectMultipleRecords(string query, Dictionary<string, object> parameters,
            Func<SqlDataReader, T> getItemFromReader)
        {
            List<T> items = new List<T>();

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = CreateCommandWithParameters(query, connection, parameters);

                items = GetMultipleItemsFromReader(command, getItemFromReader);
            }

            return items;
        }

        private List<T> GetMultipleItemsFromReader(SqlCommand command, Func<SqlDataReader, T> getItemFromReader)
        {
            List<T> items = new List<T>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                T item = getItemFromReader(reader);
                items.Add(item);
            }

            return items;
        }
       
        public T SelectSingleRecord(string query, Dictionary<string, object> parameters, 
            Func<SqlDataReader, T> getItemFromReader)
        {
            T item = default(T);

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = CreateCommandWithParameters(query, connection, parameters);

                item = GetSingleItemFromReader(command, getItemFromReader);
            }

            return item;
        }

        private T GetSingleItemFromReader(SqlCommand command, Func<SqlDataReader, T> getItemFromReader)
        {
            T item = default(T);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                item = getItemFromReader(reader);
            }

            return item;
        }

        public bool ExecQueryOneRecord(string query, Dictionary<string, object> parameters)
        {
            int affectedRows = 0;

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = CreateCommandWithParameters(query, connection, parameters);

                affectedRows = command.ExecuteNonQuery();
            }

            return (affectedRows == 1);
        }

        public int ExecQueryGetScalar(string query, Dictionary<string, object> parameters)
        {
            int i = 0;

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand command = CreateCommandWithParameters(query, connection, parameters);

                i = Convert.ToInt32(command.ExecuteScalar());
            }

            return i;
        }

        private SqlDataReader GetReaderFromSelect(string query, Dictionary<string, object> parameters)
        {
            SqlCommand command = null;
            SqlDataReader reader = null;

            using (SqlConnection connection = CreateConnection())
            {
                SqlCommand cmd = CreateCommandWithParameters(query, connection, parameters);

                reader = command.ExecuteReader();
            }

            return reader;
        }

        private SqlConnection CreateConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FIM"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        private SqlCommand CreateCommandWithParameters(string query, SqlConnection connection, 
            Dictionary<string, object> parameters)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Connection.Open();

            foreach (string paramKey in parameters.Keys)
            {
                command.Parameters.AddWithValue(paramKey, parameters[paramKey]);
            }

            return command;
        }
    }
}
