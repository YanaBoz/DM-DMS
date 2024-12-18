using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.SqlClient;

namespace SUBD
{
    internal class EmployeePosition
    {
        public int Employee_ID { get; set; }
        public int Position_ID { get; set; }

        public string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

        public async Task Add(int x, int y)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"INSERT INTO EmployeePosition (Employee_ID, Position_ID) VALUES ('{x}','{y}')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number/2}");
                await connection.CloseAsync();
            }
        }
        public async Task Delete(int x, int y)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"DELETE FROM EmployeePosition WHERE (Employee_ID = '{x}' AND Position_ID = '{y}')";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Удалено объектов: {number}");
                await connection.CloseAsync();
            }
        }
        public async Task Show()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sqlExpression = $"SELECT * FROM EmployeePosition";
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
                        int? id2 = result.IsDBNull(1) ? null : result.GetInt32(1);
                        Console.WriteLine("{0}\t{1}",
                            id,
                            id2);
                    }
                }
                Console.WriteLine($"Объектов: {number}");
                await connection.CloseAsync();
            }
        }
    }
}
