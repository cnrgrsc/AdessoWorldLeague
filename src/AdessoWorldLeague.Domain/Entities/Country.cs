namespace AdessoWorldLeague.Domain.Entities
{
    /// <summary>
    /// Ülke sınıfı
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Ülkenin benzersiz kimliği
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ülkenin adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ülkeye ait takımların listesi
        /// </summary>
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
