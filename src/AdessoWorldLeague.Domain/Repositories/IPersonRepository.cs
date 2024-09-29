using AdessoWorldLeague.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Domain.Repositories
{
    /// <summary>
    /// Kişi (Person) repository arayüzü
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Yeni kişi ekleme
        /// </summary>
        Task AddAsync(Person person);

        /// <summary>
        /// Kişi güncelleme
        /// </summary>
        Task UpdateAsync(Person person);

        /// <summary>
        /// Kişi silme
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Id'ye göre kişi getirme
        /// </summary>
        Task<Person> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm kişileri getirme
        /// </summary>
        Task<IEnumerable<Person>> GetAllAsync();
        //Task<Person> GetByFirstNameLastNameAsync(string firstName, string lastName);
    }
}
