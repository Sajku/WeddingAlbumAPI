using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class GetEventAlbumsUseCase : IQueryHandler<GetEventAlbumsParameter, List<UserAlbumInEventDTO>>
    {
        private readonly IEventQuery _eventQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetEventAlbumsUseCase(IEventQuery eventQuery, ICurrentUserService currentUserService)
        {
            _eventQuery = eventQuery;
            _currentUserService = currentUserService;
        }

        public async Task<List<UserAlbumInEventDTO>> Handle(GetEventAlbumsParameter query)
        {
            query.UserId = _currentUserService.UserId;
            return await _eventQuery.GetEventAlbums(query);
        }
    }
}
