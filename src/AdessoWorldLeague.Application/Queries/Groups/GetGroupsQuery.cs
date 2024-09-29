using AdessoWorldLeague.Application.Queries.Groups.Dtos;
using MediatR;

namespace AdessoWorldLeague.Application.Queries.Groups

{

    /// <summary>
    /// Grupları getirmek için sorgu sınıfı
    /// </summary>
    public class GetGroupsQuery : IRequest<List<GroupDto>>
    {
        /// <summary>
        /// Kura Id'si
        /// </summary>
        public Guid DrawId { get; set; }
    }
}
