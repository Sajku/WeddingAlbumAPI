using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.PhotoInAlbums
{
    public class GetPhotoInAlbumsUseCase : IQueryHandler<GetPhotoInAlbumsParameter, List<PhotoInAlbumDTO>>
    {
        private readonly IPhotoInAlbumQuery _photoInAlbumQuery;

        public GetPhotoInAlbumsUseCase(IPhotoInAlbumQuery photoInAlbumQuery)
        {
            _photoInAlbumQuery = photoInAlbumQuery;
        }

        public async Task<List<PhotoInAlbumDTO>> Handle(GetPhotoInAlbumsParameter query)
        {
            return await _photoInAlbumQuery.GetPhotoInAlbums(query);
        }
    }
}
