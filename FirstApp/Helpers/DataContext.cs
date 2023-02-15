using Microsoft.Extensions.Configuration;
using FirstApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("Database"));
        }

        public DbSet<User> Users { get; set; }
    }
}
