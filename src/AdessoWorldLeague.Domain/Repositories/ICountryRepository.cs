using AdessoWorldLeague.Domain.Entities;

namespace AdessoWorldLeague.Domain.Repositories
{
    /// <summary>
    /// Ülke (Country) repository arayüzü
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Yeni ülke ekleme
        /// </summary>
        Task AddAsync(Country country);

        /// <summary>
        /// Ülke güncelleme
        /// </summary>
        Task UpdateAsync(Country country);

        /// <summary>
        /// Ülke silme
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Id'ye göre ülke getirme
        /// </summary>
        Task<Country> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm ülkeleri getirme
        /// </summary>
        Task<IEnumerable<Country>> GetAllAsync();
    }
}
