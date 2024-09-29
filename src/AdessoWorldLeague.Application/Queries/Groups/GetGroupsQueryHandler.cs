using AdessoWorldLeague.Application.Queries.Groups.Dtos;
using AdessoWorldLeague.Domain.Repositories;
using MediatR;



namespace AdessoWorldLeague.Application.Queries.Groups

{
    /// <summary>
    /// GetGroupsQuery için Handler sınıfı
    /// </summary>
    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupDto>>
    {
        private readonly IDrawRepository _drawRepository;

        public GetGroupsQueryHandler(IDrawRepository drawRepository)
        {
            _drawRepository = drawRepository;
        }

        public async Task<List<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            // Belirli bir kura için grupları getirme
            var draw = await _drawRepository.GetByIdAsync(request.DrawId); //.value kontol edilecek.

            if (draw == null)
            {
                throw new Exception("Kura bulunamadı.");
            }

            var groupDtos = draw.Groups.Select(g => new GroupDto
            {
                GroupName = g.Name,
                Teams = g.Teams.Select(t => new TeamDto
                {
                    Name = t.Name.Value
                }).ToList()
            }).ToList();

            return groupDtos;
        }
    }
}
