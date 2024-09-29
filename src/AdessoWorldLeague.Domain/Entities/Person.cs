using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Domain.Entities
{
    /// <summary>
    /// Kura çeken kişi sınıfı
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Kişinin benzersiz kimliği
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Kişinin adı
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Kişinin soyadı
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Kişinin çektiği kuraların listesi
        /// </summary>
        public List<Draw> Draws { get; set; } = new List<Draw>();
    }

}
