using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoWorldLeague.Application.Queries.Groups.Dtos
{
    /// <summary>
    /// Grup DTO sınıfı
    /// </summary>
    public class GroupDto
    {
        /// <summary>
        /// Grup adı
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Gruptaki takımlar
        /// </summary>
        public List<TeamDto> Teams { get; set; }
    }
}
