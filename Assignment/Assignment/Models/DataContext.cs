using Assignment.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "StudentDb");

        }

    }
}

