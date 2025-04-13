using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Data;
using Welcome.Model;


namespace WelcomeExtended.Helpers
{
    static class UserHelper
    {
        public static string ToUserString(this User user)
        {
            return $"User: {user.Name}, Role: {user.Role}, Expires: {user.Expires}";
        }
        public static string ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "The name cannot be empty";
            if (string.IsNullOrWhiteSpace(password))
                return "The password cannot be empty";

            var isValid = userData.ValidateUser(name, password);

            return isValid ? "Valid user" : "Invalid credentials";
        }
        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
