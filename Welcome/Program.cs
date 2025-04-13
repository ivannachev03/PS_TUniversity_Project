using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User user = new User(1, "Ivan", "123456", Others.UserRolesEnum.ADMIN, DateTime.Now.AddMonths(3));
            UserViewModel viewModel = new UserViewModel(user);
            UserView view = new UserView(viewModel);

            view.Display();
        }
    }
}
