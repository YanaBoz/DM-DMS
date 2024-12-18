using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    internal class User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

        public async Task Add(string x, string y, string z, int p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO [User] ([User_Name], [Password],[Age],[Email]) VALUES (@User_Name, @Password, @Age, @Email)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@User_Name", x);
                command.Parameters.AddWithValue("@Password", y);
                command.Parameters.AddWithValue("@Email", z);
                command.Parameters.AddWithValue("@Age", p);
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
                string sqlExpression = $"DELETE FROM  [User] WHERE ([User_ID] = @Position_ID)";
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
                string sqlExpression = $"SELECT * FROM [User]";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4)
                        );

                    while (result.Read())
                    {
                        number++;
                        int id = result.GetInt32(0);
                        string id2 = result.GetString(1);
                        string id3 = result.GetString(2);
                        int id5  = result.GetInt32(3);
                        string id4 = result.GetString(4);
                        Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}",
                            id,
                            id2,
                            id3,
                            id5,
                            id4
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
    }
}
