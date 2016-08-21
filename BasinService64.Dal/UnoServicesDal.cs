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
    public class UnoServicesDal
    {
        public List<UnoServiceDto> GetAllUnoServices()
        {
            var result = new List<UnoServiceDto>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "SELECT [Id], [Title], [Price], [Annotation] FROM [UnoServices] ORDER BY [Title] DESC;";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new UnoServiceDto()
                            {
                                ID = (int)reader["Id"],
                                Title = (string)reader["Title"],
                                Price = (string)reader["Price"],
                                Annotation = (string)reader["Annotation"]
                            });
                        }
                    }
                }
            }

            return result;
        }

        public UnoServiceDto GetUnoService(int id)
        {
            var result = new UnoServiceDto();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "SELECT [Id], [Title], [Price], [Annotation] FROM [UnoServices] WHERE [Id] = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.ID = (int)reader["Id"];
                            result.Title = (string)reader["Title"];
                            result.Price = (string)reader["Price"];
                            result.Annotation = (string)reader["Annotation"];
                        }
                    }
                }
            }

            return result;
        }

        public void AddUnoService(UnoServiceDto item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string procedureName = "AddUnoService";

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter RetId = command.Parameters.Add("RetVal", SqlDbType.Int);
                    RetId.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.AddWithValue("@Title", item.Title);
                    command.Parameters.AddWithValue("@Price", item.Price);
                    command.Parameters.AddWithValue("@Annotation", item.Annotation);

                    connection.Open();
                    command.ExecuteNonQuery();

                    item.ID = (int)RetId.Value;
                }
            }
        }

        public void DeleteUnoService(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "DELETE FROM [UnoServices] WHERE [Id] = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUnoService(UnoServiceDto item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "UPDATE [UnoServices] SET [Title] = @Title, [Price] = @Price, [Annotation] = @Annotation WHERE [Id] = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", item.ID.ToString());
                    command.Parameters.AddWithValue("@Title", item.Title.ToString());
                    command.Parameters.AddWithValue("@Price", item.Price.ToString());
                    command.Parameters.AddWithValue("@Annotation", item.Annotation.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
