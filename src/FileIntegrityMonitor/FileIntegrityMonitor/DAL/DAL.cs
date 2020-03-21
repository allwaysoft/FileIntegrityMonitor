using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FileIntegrityMonitor.DAL
{
    public class DALBase<T>
    {
        public List<T> SelectMultipleRecords(string query, Dictionary<string, object> parameters,
            Func<SqlDataReader, T> getItemFromReader)
        {
            List<T> items = new List<T>();
            SqlDataReader reader = GetReaderFromSelect(query, parameters);

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
            SqlDataReader reader = GetReaderFromSelect(query, parameters);

            if (reader.Read())
            {
                item = getItemFromReader(reader);
            }

            return item;
        }

        public bool ExecQueryOneRecord(string query, Dictionary<string, object> parameters)
        {
            SqlCommand command = GetCommandWithParameters(query, parameters);
            int affectedRows = command.ExecuteNonQuery();

            return (affectedRows == 1);
        }

        private SqlDataReader GetReaderFromSelect(string query, Dictionary<string, object> parameters)
        {
            SqlCommand command = GetCommandWithParameters(query, parameters);
            SqlDataReader  reader = command.ExecuteReader();

            return reader;
        }

        private SqlCommand GetCommandWithParameters(string query, Dictionary<string, object> parameters)
        {
            SqlCommand command = null;

            using (SqlConnection connection = new SqlConnection("blabla"))
            {
                command = new SqlCommand(query, connection);
                connection.Open();
                foreach (string paramKey in parameters.Keys)
                {
                    command.Parameters.AddWithValue(paramKey, parameters[paramKey]);
                }
            }

            return command;
        }
    }
}
