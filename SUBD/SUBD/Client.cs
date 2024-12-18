using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    internal class Client
    {
        public int Clent_ID { get; set; }
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Patronymic { get; set; }
        public string Notes { get; set; }
        public string Phone_Number { get; set; }
        public int Has_Child { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

        public async Task Add(int v, string x, string y, string z, string h, string c, byte t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO Client ([User_ID], [First_Name], [Last_Name], [Patronymic], [Notes], [Phone_Number], [Has_Child]) VALUES (@UserId, @FirstName, @LastName, @Patronymic, @Notes, @Phone_Number, @HasChild)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@UserId", v);
                command.Parameters.AddWithValue("@FirstName", x);
                command.Parameters.AddWithValue("@LastName", y);
                command.Parameters.AddWithValue("@Patronymic", z);
                command.Parameters.AddWithValue("@Notes", h);
                command.Parameters.AddWithValue("@Phone_Number", c);
                command.Parameters.AddWithValue("@HasChild", t);
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
                string sqlExpression = $"DELETE FROM Client WHERE (Client_ID = @Client_ID)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@Client_ID", x);
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
                string sqlExpression = $"SELECT * FROM Client";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4),
                        result.GetName(5),
                        result.GetName(6),
                        result.GetName(7)
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
                        byte chill = result.GetByte(7);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                            id,
                            id2,
                            notes,
                            disc_val,
                            disc_type,
                            num,
                            date,
                            chill
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
        public async Task Show_Room()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"SELECT * FROM Room";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4),
                        result.GetName(5)
                        );

                    while (result.Read())
                    {
                        number++;
                        int id = result.GetInt32(0);
                        int id2 = result.GetInt32(1);
                        byte notes = result.GetByte(2);
                        int disc_val = result.GetInt32(3);
                        string disc_type = result.GetString(4);
                        string num = result.GetString(5);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            id,
                            id2,
                            notes,
                            disc_val,
                            disc_type,
                            num
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
        public async Task Show_PROM()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"SELECT * FROM PromoCode";
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
                        int id2 = result.GetInt32(1);
                        string notes = result.GetString(2);
                        string disc_val = result.GetString(3);
                        double disc_type = result.GetDouble(4);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                            id,
                            id2,
                            notes,
                            disc_val,
                            disc_type
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
    }
}
