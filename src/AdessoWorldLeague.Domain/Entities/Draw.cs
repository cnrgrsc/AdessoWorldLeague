using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Domain.Entities
{
    /// <summary>
    /// Kura sınıfı
    /// </summary>
    public class Draw
    {
        
        /// <summary>
        /// Kuranın benzersiz kimliği
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Kuranın çekildiği tarih ve saat
        /// </summary>
        public DateTime DrawDate { get; set; }

        /// <summary>
        /// Kuranın çekildiği kişi kimliği
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Kuranın çekildiği kişi
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Kura sonucunda oluşan gruplar
        /// </summary>
        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
