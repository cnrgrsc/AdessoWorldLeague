// Dosya Yolu: AdessoLeague.Domain/Repositories/ITeamRepository.cs
using AdessoWorldLeague.Domain.Entities;

namespace AdessoWorldLeague.Domain.Repositories
{
    /// <summary>
    /// Takım repository arayüzü
    /// </summary>
    public interface ITeamRepository
    {
        /// <summary>
        /// Yeni takım ekleme
        /// </summary>
        Task AddAsync(Team team);

        /// <summary>
        /// Takım güncelleme
        /// </summary>
        Task UpdateAsync(Team team);

        /// <summary>
        /// Takım silme
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Id'ye göre takım getirme
        /// </summary>
        Task<Team> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm takımları getirme
        /// </summary>
        Task<IEnumerable<Team>> GetAllAsync();

        /// <summary>
        /// Ülkeye göre takımları getirme
        /// </summary>
        Task<IEnumerable<Team>> GetByCountryIdAsync(Guid countryId);
    }
}
