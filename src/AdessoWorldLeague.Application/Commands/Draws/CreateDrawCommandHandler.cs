
using AdessoLeague.Domain.ValueObjects;
using AdessoWorldLeague.Domain.Entities;
using AdessoWorldLeague.Domain.Repositories;
using MediatR;

namespace AdessoWorldLeague.Application.Commands.Draws
{
    /// <summary>
    /// CreateDrawCommand için Handler sınıfı
    /// </summary>
    public class CreateDrawCommandHandler : IRequestHandler<CreateDrawCommand, Guid>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IDrawRepository _drawRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IPersonRepository _personRepository;

        /// <summary>
        /// Oluşturucu metot, gerekli bağımlılıkları enjekte ediyoruz
        /// </summary>
        public CreateDrawCommandHandler(
            ITeamRepository teamRepository,
            IDrawRepository drawRepository,
            IGroupRepository groupRepository,
            IPersonRepository personRepository)
        {
            _teamRepository = teamRepository;
            _drawRepository = drawRepository;
            _groupRepository = groupRepository;
            _personRepository = personRepository;
        }

        /// <summary>
        /// Komutun işlenmesi
        /// </summary>
        public async Task<Guid> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
        {
            // Kura çeken kişi oluşturma veya mevcutsa getirme
            var person = new Person
            {
           Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _personRepository.AddAsync(person);

            // Tüm takımları getirme
            var teams = await _teamRepository.GetAllAsync();

            // Takımları karıştırma (randomize)
            var random = new Random();
            var shuffledTeams = teams.OrderBy(x => random.Next()).ToList();

            // Grup isimlerini oluşturma
            var groupNames = GenerateGroupNames(request.NumberOfGroups);

            // Grupları oluşturma
            var groups = groupNames.Select(name => new Group
            {
                Name = name,
                Teams = new List<Team>()
            }).ToList();

            // Takımları gruplara yerleştirme
            var distributionResult = DistributeTeamsToGroups(shuffledTeams, groups);

            if (!distributionResult)
            {
                throw new Exception("Takımlar gruplara dağıtılamadı. Lütfen kuralları kontrol edin.");
            }

            // Kura oluşturma
            var draw = new Draw
            {
                DrawDate = DateTime.UtcNow,
                PersonId = person.Id,
                Person = person,
                Groups = groups,
                
            };

            // Kura ve grupları veritabanına kaydetme
            await _drawRepository.AddAsync(draw);

            return draw.Id;
        }

        /// <summary>
        /// Grup isimlerini oluşturma
        /// </summary>
        private List<string> GenerateGroupNames(int numberOfGroups)
        {
            var groupNames = new List<string>();
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < numberOfGroups; i++)
            {
                groupNames.Add(letters[i].ToString());
            }
            return groupNames;
        }

        /// <summary>
        /// Takımları gruplara dağıtma işlemi
        /// Her grupta aynı ülkeden sadece bir takım olacak şekilde dağıtım yapar
        /// </summary>
        private bool DistributeTeamsToGroups(List<Team> teams, List<Group> groups)
        {
            var teamsPerGroup = teams.Count / groups.Count;

            // Ülkelere göre takımları gruplandırma
            var countryTeams = teams.GroupBy(t => t.CountryId).ToDictionary(g => g.Key, g => new Queue<Team>(g));

            // Her turda her gruba bir takım ekliyoruz
            for (int round = 0; round < teamsPerGroup; round++)
            {
                foreach (var group in groups)
                {
                    // Her ülkeden bir takım seçmeye çalışıyoruz
                    var countryIds = countryTeams.Keys.ToList();

                    bool teamAdded = false;
                    foreach (var countryId in countryIds)
                    {
                        // Eğer grup, bu ülkeden bir takım içermiyorsa
                        if (!group.Teams.Any(t => t.CountryId == countryId))
                        {
                            if (countryTeams[countryId].Count > 0)
                            {
                                var team = countryTeams[countryId].Dequeue();
                                group.Teams.Add(team);
                                teamAdded = true;
                                break;
                            }
                        }
                    }

                    // Eğer hiçbir takım eklenemediyse, kurallara uygun dağıtım yapılamıyor demektir
                    if (!teamAdded)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
