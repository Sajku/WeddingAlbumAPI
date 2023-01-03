using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class GetEventPhotosUseCase : IQueryHandler<GetEventPhotosParameter, List<ShortPhotoDTO>>
    {
        private readonly IEventQuery _eventQuery;

        public GetEventPhotosUseCase(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<List<ShortPhotoDTO>> Handle(GetEventPhotosParameter query)
        {
            return await _eventQuery.GetEventPhotos(query);
        }
    }
}
