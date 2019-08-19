using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DbOps
{
    public class BaseRepository
    {
        protected string connectionString = "Data Source=.;Initial Catalog=myShop;Integrated Security=True";
        protected string tableName;

        public virtual DataTable Listdt()
        {
            string queryString = @"select * from " + tableName;
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                connection.Close();
            }
            return dt;
        }

        public virtual void Delete(int Id)
        {
            string queryString = String.Format("delete from {0} where Id={1}", tableName, Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

    }
}