using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    internal class Position
    {
        public int Position_ID {  get; set; }
        public string Position_Name { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

        public async Task Add(string x)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO Position ([Position_Name]) VALUES (@Position_Name)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@Position_Name", x);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {rowsAffected}");
                await connection.CloseAsync();
            }

        }
        public async Task Delete(int x)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"DELETE FROM Position WHERE (Position_ID = @Position_ID)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@Position_ID", x);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Удалено объектов: {rowsAffected}");
                await connection.CloseAsync();
            }
        }
        public async Task Show()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"SELECT * FROM Position";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1}",
                        result.GetName(0),
                        result.GetName(1)
                        );

                    while (result.Read())
                    {
                        number++;
                        int id = result.GetInt32(0);
                        string id2 = result.GetString(1);
                        Console.WriteLine("{0}\t{1}",
                            id,
                            id2
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
    }
}
