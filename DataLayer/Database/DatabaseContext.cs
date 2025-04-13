using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<LogEntry> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source = {databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "Ivan",
                Password = "ivan2003",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(10),
            };
            var user1 = new DatabaseUser()
            {
                Id = 2,
                Name = "Petar",
                Password = "petar2003",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(15),
            };
            var user2 = new DatabaseUser()
            {
                Id = 3,
                Name = "teodor",
                Password = "teodor2003",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(8),
            };
            var user3 = new DatabaseUser()
            {
                Id = 4,
                Name = "Angel",
                Password = "angel2003",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(10),
            };
            modelBuilder.Entity<DatabaseUser>().HasData(user, user1, user2, user3);
        }
        
    }
}
