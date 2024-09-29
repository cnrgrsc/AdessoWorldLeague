using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Repositories
{
    /// <summary>
    /// GroupRepository implementasyonu
    /// </summary>
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Group group)
        {
            try
            {
                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex  )
            {

                throw;
            }
          
        }

        public async Task DeleteAsync(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.Include(g => g.Teams).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(Guid id)
        {
            return await _context.Groups.Include(g => g.Teams)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }
    }
}
