using BasinService64.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasinService64.Dal
{
    public class ProductDao
    {
        public void Add(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string procedureName = "AddProductBase";

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter RetId = command.Parameters.Add("RetVal", SqlDbType.Int);
                    RetId.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.AddWithValue("@ProductTitle", product.Title);
                    command.Parameters.AddWithValue("@ProductArticle", product.Article);
                    command.Parameters.AddWithValue("@ProductTypeId", 2);

                    connection.Open();
                    command.ExecuteNonQuery();

                    product.ID = (int)RetId.Value;
                }
            }
        }

        public Product Get(int id)
        {
            var result = new Product();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "SELECT [Product_base_id], [Title], [Article] FROM [ProductBase] WHERE [Product_base_id] = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.ID = (int)reader["Product_base_id"];
                            result.Title = (string)reader["Title"];
                            result.Article = (string)reader["Article"];
                        }
                    }
                }
            }

            if (result.ID == 0)
            {
                result = null;
            }

            return result;
        }

        public bool Modify(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                string query = $"UPDATE [ProductBase] SET [Title] = {product.Title}, [Article] = {product.Article} WHERE [Product_base_id] = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", product.ID);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
    }
}
