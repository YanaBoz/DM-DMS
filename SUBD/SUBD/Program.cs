using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage.Json;
using SUBD;
using System;
using System.Data;
using System.IO.Pipelines;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-DP1IFSV;Initial Catalog=MDSMDB;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза данных: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСостояние: {connection.State}");
                Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
                await connection.CloseAsync();
                Console.ReadLine();
            }
            Client Cl = new();
            EmployeePosition EP = new();
            Contact C = new();
            Position P = new();
            User U = new();
            Reservation R = new();
            bool play = true;
            while (play)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие...");
                Console.WriteLine("1. Добавить аккаунт");
                Console.WriteLine("2. Добавить работника");
                Console.WriteLine("3. Добавить должность");
                Console.WriteLine("4. Установить должность работнику");
                Console.WriteLine("5. Зарезервировать номер");
                Console.WriteLine("6. Удалить запись...");
                Console.WriteLine("7. Показать всё");
                Console.WriteLine("0. Выход");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    U.Show();
                    Console.WriteLine("Введите никнейм:");
                    string x = Console.ReadLine();
                    Console.WriteLine("Введите пароль:");
                    string y = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    int z = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите почту:");
                    string p = Console.ReadLine();
                    U.Add(x, y, p, z);
                }
                if (choose == 2)
                {
                    U.Show();
                    Console.WriteLine("Введите айди пользователя:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите имя:");
                    string y = Console.ReadLine();
                    Console.WriteLine("Введите фамилию:");
                    string z = Console.ReadLine();
                    Console.WriteLine("Введите отчество:");
                    string p = Console.ReadLine();
                    Console.WriteLine("Введите заметки:");
                    string y2 = Console.ReadLine();
                    Console.WriteLine("Введите адресс картинки:");
                    string z2 = Console.ReadLine();
                    Console.WriteLine("Введите номер:");
                    string p2 = Console.ReadLine();
                    Console.WriteLine("Есть дети?");
                    Console.WriteLine("1 да");
                    Console.WriteLine("0 нет");
                    byte p3 = Convert.ToByte(Console.ReadLine());
                    await C.Add(x, y, z, p, y2, z2);
                    await Cl.Add(x, y, z, p, y2, p2, p3);
                }
                if (choose == 3)
                {
                    P.Show();
                    Console.WriteLine("Введите название должности:");
                    string y = Console.ReadLine();
                    await P.Add(y);
                }
                if (choose == 4)
                {
                    P.Show();
                    C.Show();
                    Console.WriteLine("Введите айди работника:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите айди должности:");
                    int y = Convert.ToInt32(Console.ReadLine());
                    EP.Add(x, y);
                }
                if (choose == 5)
                {
                    R.proc();
                    Cl.Show();
                    Cl.Show_Room();
                    Cl.Show_PROM();
                    Console.WriteLine("Введите айди клиента:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите айди промокода:");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите айди комнаты:");
                    int z = Convert.ToInt32(Console.ReadLine());
                    string a1;
                    DateTime a;
                    do
                    {
                        Console.WriteLine("Введите дату заезда:");
                        a1 = Console.ReadLine();
                    } while (!DateTime.TryParse(a1, out a));
                    string d1;
                    DateTime d;
                    do
                    {
                        Console.WriteLine("Введите дату выезда:");
                        d1 = Console.ReadLine();
                    } while (!DateTime.TryParse(d1, out d));
                    Console.WriteLine("Введите цену(можно 0):");
                    double p = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите описание:");
                    string n = Console.ReadLine();
                    R.Add(x,y,z,a,d,p,n);
                }
                if (choose == 6)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие...");
                    Console.WriteLine("1. Удалить аккаунт");
                    Console.WriteLine("2. Удалить работника");
                    Console.WriteLine("3. Удалить должность");
                    Console.WriteLine("4. Удалить должность работнику");
                    Console.WriteLine("5. Удалить Резарезерв");
                    Console.WriteLine("0. Выход");
                    int del = Convert.ToInt32(Console.ReadLine());
                    if (del == 1)
                    {
                        U.Show();
                        Console.WriteLine("Айди:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        U.Delete(id);
                    }
                    if (del == 2)
                    {
                        Cl.Show();
                        Console.WriteLine("Айди:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Cl.Delete(id);
                    }
                    if (del == 3)
                    {
                        P.Show();
                        Console.WriteLine("Айди:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        P.Delete(id);
                    }
                    if (del == 4)
                    {
                        EP.Show();
                        Console.WriteLine("Айди работника:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Айди должности:");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        EP.Delete(id, id1);
                    }
                    if (del == 5)
                    {
                        R.Show();
                        Console.WriteLine("Айди:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        R.Delete(id);
                    }
                    if (del == 0)
                    {

                    }
                }
                if (choose == 7)
                {
                    Console.WriteLine("Клиенты:");
                    Cl.Show();
                    Console.WriteLine("Контакты:");
                    C.Show();
                    Console.WriteLine("Должности:");
                    P.Show();
                    Console.WriteLine("Работники и должности:");
                    EP.Show();
                    Console.WriteLine("Бронь:");
                    R.Show();
                    Console.WriteLine("Юзеры:");
                    U.Show();
                    Console.ReadLine();
                }
                if (choose == 0)
                {
                    play = false;
                }
            }
            Console.WriteLine("Подключение закрыто...");
            Console.WriteLine("Программа завершила работу.");
        }
    }
}