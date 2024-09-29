using AdessoLeague.Domain.ValueObjects;

namespace AdessoWorldLeague.Domain.Entities
{

    /// <summary>
    /// Takım sınıfı
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Takımın benzersiz kimliği
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Takımın adı (Value Object)
        /// </summary>
        public TeamName Name { get; set; }

        /// <summary>
        /// Takımın ait olduğu ülkenin kimliği
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Takımın ait olduğu ülke
        /// </summary>
        public Country Country { get; set; }
    }

}
