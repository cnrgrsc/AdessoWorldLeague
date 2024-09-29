using AdessoLeague.Domain.ValueObjects;

namespace AdessoWorldLeague.Domain.Entities
{
    /// <summary>
    /// Grup sınıfı
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Grubun benzersiz kimliği
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Grubun adı (Value Object)
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gruptaki takımların listesi
        /// </summary>
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
