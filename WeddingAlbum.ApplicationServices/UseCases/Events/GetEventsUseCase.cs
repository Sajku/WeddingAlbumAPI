using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class GetEventsUseCase : IQueryHandler<GetEventsParameter, List<EventDTO>>
    {
        private readonly IEventQuery _eventQuery;

        public GetEventsUseCase(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<List<EventDTO>> Handle(GetEventsParameter query)
        {
            return await _eventQuery.GetEvents(query);
        }
    }
}
