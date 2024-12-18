using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    internal class Reservation
    {
        public int Reservation_ID { get; set; }
        public int Client_ID { get; set; }
        public int Room_ID { get; set; }
        public DateTime Arrival_Date { get; set; }
        public DateTime Departure_Date { get; set; }
        public double Final_Price { get; set; }
        public DateTime Created_At { get; set; }
        public string Notes { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

        public async Task Add(int id, int id3, int id2, DateTime x, DateTime y, double z, string p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DateTime Now = DateTime.Now;
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO [Reservation] ([Client_ID],[Promo_ID], [Room_ID],[Arrival_Date],[Departure_Date], [Final_Price], [Created_At], [Notes]) " +
                    $"VALUES (@Client_ID,@Promo, @Room_ID, @Arrival_Date, @Departure_Date, @FinalPrice, @Date, @Notes)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@Client_ID", id);
                command.Parameters.AddWithValue("@Promo", id3);
                command.Parameters.AddWithValue("@Room_ID", id2);
                command.Parameters.AddWithValue("@Arrival_Date", x);
                command.Parameters.AddWithValue("@Departure_Date", y);
                command.Parameters.AddWithValue("@FinalPrice", z);
                command.Parameters.AddWithValue("@Date", Now);
                command.Parameters.AddWithValue("@Notes", p);
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
                string sqlExpression = $"DELETE FROM  [Reservation] WHERE ([Reservation_ID] = @Position_ID)";
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
                string sqlExpression = $"SELECT * FROM [Reservation]";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = 0;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4),
                        result.GetName(5),
                        result.GetName(6),
                        result.GetName(7),
                        result.GetName(8)
                        );

                    while (result.Read())
                    {
                        int id = result.GetInt32(0);
                        int name = result.GetInt32(1);
                        int name2 = result.GetInt32(2);
                        int notes = result.GetInt32(3);
                        double disc_val = result.GetDouble(6);
                        DateTime date3 = result.GetDateTime(7);
                        string num = result.GetString(8);
                        DateTime date = result.GetDateTime(4);
                        DateTime date2 = result.GetDateTime(5);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7} \t{8}",
                            id,
                            name,
                            name2,
                            notes,
                            date,
                            date2,
                            disc_val,
                            date3,
                            num
                            );
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
        public async Task proc()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("Reservation_Out", connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8} \t{9} \t{10}               \t{11}             \t{12}",
                        result.GetName(0),
                        result.GetName(1),
                        result.GetName(2),
                        result.GetName(3),
                        result.GetName(4),
                        result.GetName(5),
                        result.GetName(6),
                        result.GetName(7),
                        result.GetName(8),
                        result.GetName(9),
                        result.GetName(10),
                        result.GetName(11),
                        result.GetName(12)
                        );

                    while (result.Read())
                    {
                        int id = result.GetInt32(0);
                        string name = result.GetString(1);
                        string notes = result.GetString(2);
                        double disc_val = result.GetDouble(3);
                        string disc_type = result.GetString(4);
                        byte num = result.GetByte(5);
                        DateTime date = result.GetDateTime(6);
                        DateTime date2 = result.GetDateTime(7);
                        double price = result.GetDouble(8);
                        DateTime date3 = result.GetDateTime(9);
                        string note = result.GetString(10);
                        string stat = result.GetString(11);
                        string av = result.GetString(12);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}",
                            id,
                            name,
                            notes,
                            disc_val,
                            disc_type,
                            num,
                            date,
                            date2,
                            price,
                            date3,
                            note,
                            stat,
                            av
                            );
                    }
                }
                result.Close();
            }
        }
    }
}
