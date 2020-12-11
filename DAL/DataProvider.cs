using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider 
    {
        private static DataProvider instance;
        string Strdata = @"Data Source=.\;Initial Catalog=QuocKhanh;Integrated Security=True";

        public static DataProvider Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }
        private DataProvider() { }
        public DataTable Excutequery(string query)
        {
            SqlConnection connection = new SqlConnection(Strdata);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public int ExecuteNonquery(string query) 
        {
            int accpectedRows = 0;
            SqlConnection connection = new SqlConnection(Strdata);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            accpectedRows = command.ExecuteNonQuery();
            connection.Close();
            return accpectedRows;
        }
    }
}
