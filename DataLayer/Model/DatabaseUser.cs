using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace DataLayer.Model
{
    public class DatabaseUser : User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get => base.Id; set => base.Id = value; }

        public DatabaseUser()
    : base(0, "", "", UserRolesEnum.STUDENT, DateTime.Now.AddMonths(1))
        { }


    }
}
