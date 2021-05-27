using DBCRUD.Models.DBModels;
using Microsoft.EntityFrameworkCore;


namespace DBCRUDProject.DataContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<DrinkModel> Drink { get; set; }
    }
}
