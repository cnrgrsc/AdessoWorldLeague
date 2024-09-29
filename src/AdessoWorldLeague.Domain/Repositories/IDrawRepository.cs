using AdessoWorldLeague.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Domain.Repositories
{

    /// <summary>
    /// Kura repository arayüzü
    /// </summary>
    public interface IDrawRepository
    {
        /// <summary>
        /// Yeni kura ekleme
        /// </summary>
        Task AddAsync(Draw draw);

        /// <summary>
        /// Kura güncelleme
        /// </summary>
        Task UpdateAsync(Draw draw);

        /// <summary>
        /// Kura silme
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Id'ye göre kura getirme
        /// </summary>
        Task<Draw> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm kuraları getirme
        /// </summary>
        Task<IEnumerable<Draw>> GetAllAsync();

        /// <summary>
        /// Kura çeken kişiye göre kuraları getirme
        /// </summary>
        Task<IEnumerable<Draw>> GetByPersonIdAsync(Guid personId);
    }

}
