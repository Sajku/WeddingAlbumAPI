using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class GetEventAlbumsUseCase : IQueryHandler<GetEventAlbumsParameter, List<UserAlbumInEventDTO>>
    {
        private readonly IEventQuery _eventQuery;

        public GetEventAlbumsUseCase(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<List<UserAlbumInEventDTO>> Handle(GetEventAlbumsParameter query)
        {
            return await _eventQuery.GetEventAlbums(query);
        }
    }
}
