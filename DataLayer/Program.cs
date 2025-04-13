using DataLayer.Database;
using DataLayer.Loggers;
using DataLayer.Model;
using System;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using var db = new DatabaseContext();
            db.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("\n==== Меню ====");
                Console.WriteLine("1. Покажи всички потребители");
                Console.WriteLine("2. Добави нов потребител");
                Console.WriteLine("3. Изтрий потребител");
                Console.WriteLine("0. Изход");
                Console.Write("Избор: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowUsers(db);
                        break;
                    case "2":
                        AddUser(db);
                        break;
                    case "3":
                        DeleteUser(db);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невалиден избор!");
                        break;
                }
            }
        }

        static void ShowUsers(DatabaseContext db)
        {
            var users = db.Users.ToList();
            Console.WriteLine("\n--- Всички потребители ---");
            foreach (var user in users)
            {
                Console.WriteLine($"[{user.Id}] {user.Name}");
            }
            DatabaseLogger.Log(db, "Показани са всички потребители.");
        }

        static void AddUser(DatabaseContext db)
        {
            Console.Write("Въведете име: ");
            string name = Console.ReadLine();
            Console.Write("Въведете парола: ");
            string password = Console.ReadLine();

            var user = new DatabaseUser
            {
                Name = name,
                Password = password,
                Expires = DateTime.Now.AddMonths(1),
                Role = Enum.Parse<UserRolesEnum>("STUDENT")
            };

            db.Users.Add(user);
            db.SaveChanges();

            Console.WriteLine("Успешно добавен потребител.");
            DatabaseLogger.Log(db, $"Добавен нов потребител: {name}");
        }

        static void DeleteUser(DatabaseContext db)
        {
            Console.Write("Въведете име за изтриване: ");
            string name = Console.ReadLine();

            var user = db.Users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                Console.WriteLine("Потребителят е изтрит.");
                DatabaseLogger.Log(db,$"Изтрит потребител: {name}");
            }
            else
            {
                Console.WriteLine("Няма такъв потребител.");
                DatabaseLogger.Log(db, $"Опит за изтриване на несъществуващ потребител: {name}");
            }
        }
    }
}
