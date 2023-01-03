using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class GetEventDetailsUseCase : IQueryHandler<GetEventDetailsParameter, EventDTO>
    {
        private readonly IEventQuery _eventQuery;

        public GetEventDetailsUseCase(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<EventDTO> Handle(GetEventDetailsParameter query)
        {
            return await _eventQuery.GetEventDetails(query);
        }
    }
}
