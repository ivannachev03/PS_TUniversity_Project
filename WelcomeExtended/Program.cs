using WelcomeExtended.Data;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            /* 
            Console.WriteLine("Hello, World!");
            try
            {
               
                var user = new User
                {
                    Name = "John Smith",
                    Password = "password123",
                    Role = UserRolesEnum.Student
                };

                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);

                view.Display();

                
                view.DisplayError();
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
            */
            try
            {
                UserData userData = new UserData();
                User studentUser = new User("student", "123", UserRolesEnum.STUDENT);
                User studentUser2 = new User("student2", "123", UserRolesEnum.STUDENT);
                User professorUser = new User("teacher", "1234", UserRolesEnum.TEACHER);
                User AdminUser = new User("admin", "1236", UserRolesEnum.ADMIN);
                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(professorUser);
                userData.AddUser(AdminUser);


                Console.Write("Моля, въведете потребителско име: ");
                string name = Console.ReadLine();

                Console.Write("Моля, въведете парола: ");
                string password = Console.ReadLine();

                string validationMessage = userData.ValidateCredentials(name, password);

                if (validationMessage == "Valid user")
                {
                    var user = userData.GetUser(name, password);
                    Console.WriteLine(user.ToUserString());
                    Logger.LogSuccess(user.Name);
                }
                else
                {
                    Logger.LogError(name, "Невалидни потребителски данни");
                    throw new Exception("Потребителят не е намерен");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
