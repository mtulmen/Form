using System;
using Dal.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DbOps
{
    public class UserRepositry : BaseRepository
    {
        string tableName = "Users";

        public UserRepositry()
        {
            base.tableName = tableName;
        }

        public List<UserEntity> List()
        {
            List<UserEntity> userList = new List<UserEntity>();

            string queryString = "select * from Users";

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                connection.Close();
            }

            foreach (DataRow dr in dt.Rows)
            {
                UserEntity user = new UserEntity();
                user.Credit = Convert.ToDecimal(dr["Credit"]);
                user.FullName = dr["FullName"].ToString();
                user.Password = dr["Password"].ToString();
                user.UserName = dr["USerName"].ToString();
                user.Id = Convert.ToInt32(dr["Id"]);
                userList.Add(user);

            }

            return userList;

        }

        public void Insert(UserEntity user)
        {
            List<UserEntity> userList = new List<UserEntity>();

            string queryString = String.Format("insert into users values('{0}','{1}','{2}',{3})", user.FullName, user.UserName, user.Password, user.Credit);

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Update(UserEntity user)
        {
            List<UserEntity> userList = new List<UserEntity>();

            string queryString = String.Format("Update users set FullName='{0}',UserName='{1}', Password='{2}', Credit='{3}' where Id={4}", user.FullName, user.UserName, user.Password, user.Credit.ToString().Replace(',', '.'), user.Id);

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        public bool CheckLogin(string u, string p)
        {
            string queryString = string.Format("select UserName,Password from Users where Username='{0}' and Password='{1}'", u, p);

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                connection.Close();
            }
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

    }
}
