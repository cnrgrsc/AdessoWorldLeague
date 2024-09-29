// Dosya Yolu: AdessoLeague.Domain/Repositories/IGroupRepository.cs
using AdessoWorldLeague.Domain.Entities;
namespace AdessoWorldLeague.Domain.Repositories
{
    /// <summary>
    /// Grup repository arayüzü
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        /// Yeni grup ekleme
        /// </summary>
        Task AddAsync(Group group);

        /// <summary>
        /// Grup güncelleme
        /// </summary>
        Task UpdateAsync(Group group);

        /// <summary>
        /// Grup silme
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Id'ye göre grup getirme
        /// </summary>
        Task<Group> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm grupları getirme
        /// </summary>
        Task<IEnumerable<Group>> GetAllAsync();
    }
}
