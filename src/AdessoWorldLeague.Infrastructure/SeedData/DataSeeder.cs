using AdessoLeague.Domain.ValueObjects;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Infrastructure.SeedData
{
    /// <summary>
    /// Veritabanı başlangıç verilerini yüklemek için kullanılan sınıf
    /// </summary>
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Verileri yükler
        /// </summary>
        public async Task SeedAsync()
        {
            // Eğer veriler zaten yüklüyse işlem yapma
            if (await _context.Countries.AnyAsync())
                return;

            // Ülkeleri ve takımları oluşturma
            var countries = GetCountriesWithTeams();

            // Veritabanına ekleme
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Ülkeleri ve takımlarını oluşturur
        /// </summary>
        private List<Country> GetCountriesWithTeams()
        {
            return new List<Country>
            {
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Türkiye",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso İstanbul") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Ankara") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso İzmir") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Antalya") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Almanya",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Berlin") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Frankfurt") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Münih") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Dortmund") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Fransa",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Paris") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Marsilya") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Nice") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Lyon") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Hollanda",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Amsterdam") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Rotterdam") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Lahey") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Eindhoven") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Portekiz",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Lisbon") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Porto") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Braga") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Coimbra") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "İtalya",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Roma") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Milano") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Venedik") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Napoli") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "İspanya",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Sevilla") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Madrid") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Barselona") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Granada") }
                    }
                },
                new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "Belçika",
                    Teams = new List<Team>
                    {
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Brüksel") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Brugge") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Gent") },
                        new Team { Id = Guid.NewGuid(), Name = new TeamName("Adesso Anvers") }
                    }
                }
            };
        }
    }
}

