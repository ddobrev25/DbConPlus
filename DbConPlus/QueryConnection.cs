using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DbConPlus
{
    public class QueryConnection : Connection
    {
        public QueryConnection(string connectionString)
            : base(connectionString)
        {
        }
        public void ExecuteQuery(Query query)
        {
            using (SqlConnection con = new SqlConnection(base.ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query.Command, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ExecuteQuery(string command)
        {
            using (SqlConnection con = new SqlConnection(base.ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
