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
    public class ProductRepository : BaseRepository
    {
        string tableName = "Products";

        public ProductRepository()
        {
            base.tableName = tableName;
        }

        public override DataTable Listdt()
        {
            string queryString = @"select p.*,c.Name catName from Products p
join Categories c on p.categoryId = c.Id";
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

        public List<ProductEntity> List()
        {
            List<ProductEntity> ProductList = new List<ProductEntity>();
            string queryString = @"select p.*,c.Name catName from Products p
join Categories c on p.categoryId = c.Id";
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
                ProductEntity pr = new ProductEntity();
                pr.Id = Convert.ToInt32(dr["Id"]);
                pr.Name = dr["Name"].ToString();
                pr.Price = Convert.ToDecimal(dr["Price"]);
                pr.ProductCode = dr["productCode"].ToString();
                pr.Stock = Convert.ToInt32(dr["stocks"]);
                pr.CategoryId = Convert.ToInt32(dr["categoryId"]);
                pr.CatName = dr["catName"].ToString(); ;
                ProductList.Add(pr);

            }

            return ProductList;

        }

        public void Insert(ProductEntity pr)
        {
            string queryString = String.Format("insert into products values('{0}',{1},{2},{3}, '{4}')", pr.Name, pr.Stock, pr.Price, pr.CategoryId, pr.ProductCode);

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryString, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(ProductEntity pro)
        {
            List<ProductEntity> userList = new List<ProductEntity>();

            string queryString = String.Format("Update products set Name='{0}',Stock={1}, Price={2}, CategoryId={3}, ProductCode={4} where Id={5}", pro.Name,pro.Stock,pro.Price,pro.CategoryId,pro.ProductCode, pro.Id);

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
