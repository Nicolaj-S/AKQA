using AKQA.Entities;
using Microsoft.EntityFrameworkCore;

namespace AKQA.Helpers
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("connection"));
        }

        public DbSet<User> User { get; set; }

        public DbSet<Recipes> Recipes { get; set; }
    }
}
