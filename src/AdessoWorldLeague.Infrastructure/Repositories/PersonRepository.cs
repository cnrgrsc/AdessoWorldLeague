using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using AdessoWorldLeague.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Repositories
{
    /// <summary>
    /// PersonRepository implementasyonu
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.Include(p => p.Draws).ToListAsync();
        }

        public async Task<Person> GetByIdAsync(Guid id)
        {
            return await _context.Persons.Include(p => p.Draws)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
        //public async Task<Person> GetByFirstNameLastNameAsync(string firstName, string lastName)
        //{
        //    // İlgili kişiyi veritabanından çekiyoruz
        //    return await _context.Persons
        //        .FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
        //}
    }
}
