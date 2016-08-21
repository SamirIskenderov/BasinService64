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
    public class QueriesDal
    {
        public List<QueryDto> GetAllQueries()
        {
            var result = new List<QueryDto>();
            var item = new QueryDto();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "SELECT [Id], [Name], [Message], [PhoneNumber], [Email], [Date] FROM [Queries] ORDER BY [Date] DESC;";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new QueryDto()
                            {
                                ID = (int)reader["Id"],
                                Message = (string)reader["Message"],
                                Name = (string)reader["Name"],
                                PhoneNumber = (string)reader["PhoneNumber"],
                                Email = (string)reader["Email"],
                                Date = (DateTime)reader["Date"],
                            });
                        }
                    }
                }
            }

            return result;
        }

        public void AddQuery(QueryDto item)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string procedureName = "AddQuery";

                using (var command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter RetId = command.Parameters.Add("RetVal", SqlDbType.Int);
                    RetId.Direction = ParameterDirection.ReturnValue;

                    command.Parameters.AddWithValue("@Name", item.Name);
                    command.Parameters.AddWithValue("@Message", item.Message);
                    command.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", item.Email);
                    command.Parameters.AddWithValue("@Date", item.Date);

                    connection.Open();
                    command.ExecuteNonQuery();

                    item.ID = (int)RetId.Value;
                }
            }
        }

        public void DeleteQuery(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString))
            {
                const string query = "DELETE FROM [Queries] WHERE [Id] = @Id;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
