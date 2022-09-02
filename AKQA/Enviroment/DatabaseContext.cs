using AKQA.Domain;
using Microsoft.EntityFrameworkCore;

namespace AKQA.Enviroment
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Recipes> Recipes { get; set; }
    }
}
