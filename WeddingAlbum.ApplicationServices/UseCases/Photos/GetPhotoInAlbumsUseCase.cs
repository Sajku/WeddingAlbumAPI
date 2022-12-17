using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class GetPhotoInAlbumsUseCase : IQueryHandler<GetPhotoInAlbumParameter, List<PhotoInAlbumDTO>>
    {
        private readonly IPhotoQuery _photoQuery;

        public GetPhotoInAlbumsUseCase(IPhotoQuery photoQuery)
        {
            _photoQuery = photoQuery;
        }

        public async Task<List<PhotoInAlbumDTO>> Handle(GetPhotoInAlbumParameter query)
        {
            return await _photoQuery.GetPhotoInAlbums(query);
        }
    }
}
