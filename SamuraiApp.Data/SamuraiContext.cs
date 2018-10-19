using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain2;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais {get;set;}
        public DbSet<Quote> Quotes {get;set;}
        public DbSet<Battle> Battles {get;set;}

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLogger)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = SamuraiAppData; Trusted_Connection= True;"
                );
        }

        private static readonly LoggerFactory MyConsoleLogger
                    = new LoggerFactory(new[]{
                         new ConsoleLoggerProvider( (category, level)
                            => category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information, true)
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuariId, s.BattleId});
        }
    }

}
