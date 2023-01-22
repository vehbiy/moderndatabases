using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PaymentModule
{
    public class DBHelper
    {
        //private SqlConnection connection = new SqlConnection("server=.;database=PaymentModule;user id=sa;password=1234qwer");
        private SqlConnection connection = new SqlConnection("server=.;database=PaymentModule;integrated security=SSPI");

        private void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private SqlCommand CreateCommand(string sql, Dictionary<string, object> parameters)
        {
            var command = new SqlCommand(sql, connection);

            if (parameters != null)
            {
                IDictionaryEnumerator enumerator = parameters.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    command.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                }
            }

            return command;
        }

        public object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            var command = CreateCommand(sql, parameters);
            OpenConnection();
            object result = command.ExecuteScalar();
            CloseConnection();
            return result;
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            var command = CreateCommand(sql, parameters);
            OpenConnection();
            int rowCount = command.ExecuteNonQuery();
            CloseConnection();
            return rowCount;
        }

        public DataTable ExecuteDataTable(string sql, Dictionary<string, object> parameters)
        {
            var command = CreateCommand(sql, parameters);
            var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            OpenConnection();
            adapter.Fill(dataTable);
            CloseConnection();
            return dataTable;
        }
    }
}
