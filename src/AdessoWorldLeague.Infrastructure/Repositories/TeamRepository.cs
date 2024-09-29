
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Repositories
{
    /// <summary>
    /// TeamRepository implementasyonu
    /// </summary>
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            try
            {
                return await _context.Teams.Include(t => t.Country).ToListAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Team> GetByIdAsync(Guid id)
        {
            return await _context.Teams.Include(t => t.Country)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Team>> GetByCountryIdAsync(Guid countryId)
        {
            return await _context.Teams
                .Where(t => t.CountryId == countryId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
        }
    }
}
