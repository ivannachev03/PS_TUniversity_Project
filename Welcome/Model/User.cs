using Welcome.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Welcome.Model
{
    public class User
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Expires { get; set; }
        public UserRolesEnum Role { get; set; }

        public User(int id, string name, string password, UserRolesEnum userRole, DateTime expires)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = userRole;
            Expires = expires;
        }

        public User(string name, string password, UserRolesEnum role)
        {
            Name = name;
            Password = password;
            Role = role;
        }
        
    }
}