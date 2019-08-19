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
    public class CategoryRepository : BaseRepository
    {
        string tableName = "Categories";

        public CategoryRepository()
        {
            base.tableName = this.tableName;
        }

        public List<CategoryEntity> List()
        {
            List<CategoryEntity> categoryList = new List<CategoryEntity>();
            string queryString = "select * from Categories";
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
                CategoryEntity cat = new CategoryEntity();
                cat.CatOrder = Convert.ToInt32(dr["CatOrder"]);
                cat.Desc = dr["Description"].ToString();
                cat.Id = Convert.ToInt32(dr["Id"]);
                cat.Name = dr["Name"].ToString();

                categoryList.Add(cat);

            }

            return categoryList;

        }

        public void Insert(CategoryEntity ctg)
        {
            string queryString = String.Format("insert into categories values('{0}','{1}','{2}')", ctg.Name, ctg.Desc, ctg.CatOrder);

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(CategoryEntity ctg)
        {
            string queryString = String.Format("update  categories set Name='{0}', [Description]='{1}', CatOrder={2} where Id={3}", ctg.Name, ctg.Desc, ctg.CatOrder, ctg.Id);

            DataTable dt = new DataTable();
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
