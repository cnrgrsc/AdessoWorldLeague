using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Repositories
{
    /// <summary>
    /// CountryRepository implementasyonu
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.Include(c => c.Teams).ToListAsync();
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            return await _context.Countries.Include(c => c.Teams)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }
    }
}
