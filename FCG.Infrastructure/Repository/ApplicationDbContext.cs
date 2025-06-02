using Microsoft.EntityFrameworkCore;
using FCG.Core.Entity;
using Microsoft.Extensions.Configuration;

namespace FCG.Infrastructure.Repository
{
    public class ApplicationDbContext: DbContext
    {
        private readonly string? _connectionString;

        public ApplicationDbContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Usuario> Usuario {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);            
        }
    }
}
