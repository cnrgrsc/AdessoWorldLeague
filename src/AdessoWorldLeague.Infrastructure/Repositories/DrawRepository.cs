using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Infrastructure.Repositories
{
    /// <summary>
    /// DrawRepository implementasyonu
    /// </summary>
    public class DrawRepository : IDrawRepository
    {
        private readonly ApplicationDbContext _context;

        public DrawRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Draw draw)
        {
            await _context.Draws.AddAsync(draw);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var draw = await _context.Draws.FindAsync(id);
            if (draw != null)
            {
                _context.Draws.Remove(draw);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Draw>> GetAllAsync()
        {
            return await _context.Draws.Include(d => d.Groups)
                .ThenInclude(g => g.Teams)
                .ToListAsync();
        }

        public async Task<Draw> GetByIdAsync(Guid id)
        {
            return await _context.Draws.Include(d => d.Groups)
                .ThenInclude(g => g.Teams)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Draw>> GetByPersonIdAsync(Guid personId)
        {
            return await _context.Draws.Where(d => d.PersonId == personId)
                .Include(d => d.Groups)
                .ThenInclude(g => g.Teams)
                .ToListAsync();
        }

        public async Task UpdateAsync(Draw draw)
        {
            _context.Draws.Update(draw);
            await _context.SaveChangesAsync();
        }
    }
}
