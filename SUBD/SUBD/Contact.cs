using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SUBD
{
    internal class Contact
    {
        public int Conntact_ID {  get; set; }
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Patronymic { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";
        public async Task Add(int v, string x, string y, string z, string h, string c)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO Contact ([User_ID], [First_Name], [Last_Name], [Patronymic], [Description], [Photo]) VALUES (@UserId, @FirstName, @LastName, @Patronymic, @Description, @Photo)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@UserId", v);
                command.Parameters.AddWithValue("@FirstName", x);
                command.Parameters.AddWithValue("@LastName", y);
                command.Parameters.AddWithValue("@Patronymic", z);
                command.Parameters.AddWithValue("@Description", h);
                command.Parameters.AddWithValue("@Photo", c);
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
                string sqlExpression = $"DELETE FROM Contact WHERE (Contact_ID = @Contact_ID)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@Contact_ID", x);
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
                string sqlExpression = $"SELECT * FROM Contact";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4),
                        result.GetName(5),
                        result.GetName(6)
                        );

                    while (result.Read())
                    {
                        number++;
                        int id = result.GetInt32(0);
                        int id2 = result.GetInt32(1);
                        string notes = result.GetString(2);
                        string disc_val = result.GetString(3);
                        string disc_type = result.GetString(4);
                        string num = result.GetString(5);
                        string date = result.GetString(6);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
                            id,
                            id2,
                            notes,
                            disc_val,
                            disc_type,
                            num,
                            date
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
    }
}
