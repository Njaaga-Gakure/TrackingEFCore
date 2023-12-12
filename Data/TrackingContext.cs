using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrackingEFCore.Models;

namespace TrackingEFCore.Data
{
    public class TrackingContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var connectionString = configSection["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Trainee> Trainees { get; set; }    
    }
}
