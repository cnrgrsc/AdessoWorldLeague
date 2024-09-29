using MediatR;

namespace AdessoWorldLeague.Application.Commands.Draws
{
    /// <summary>
    /// Kura çekme komutu
    /// </summary>
    public class CreateDrawCommand : IRequest<Guid> // Dönüş tipi olarak Kura Id'sini dönebiliriz
    {
        /// <summary>
        /// Kura çeken kişinin adı
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Kura çeken kişinin soyadı
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Grup sayısı (4 veya 8 olmalı)
        /// </summary>
        public int NumberOfGroups { get; set; }
    }
}
