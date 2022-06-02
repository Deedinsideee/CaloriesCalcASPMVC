using WebCalculatorLast.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCalculatorLast.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Usersa> Users { get; set; }

        public DbSet<Food> Foodss { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        



    }
}
