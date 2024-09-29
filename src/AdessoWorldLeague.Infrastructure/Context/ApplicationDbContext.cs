using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Context
{
    /// <summary>
    /// Veritabanı bağlamı sınıfı
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// DbContextOptions'ı alıyoruz
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet'ler
        /// </summary>
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Draw> Draws { get; set; }

        /// <summary>
        /// Model oluşturulurken çağrılır
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity konfigürasyonlarını uyguluyoruz
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DrawConfiguration());
        }
    }
}
