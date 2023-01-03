using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Albums
{
    public class GetAlbumPhotosUseCase : IQueryHandler<GetAlbumPhotosParameter, List<ShortPhotoDTO>>
    {
        private readonly IAlbumQuery _albumQuery;

        public GetAlbumPhotosUseCase(IAlbumQuery albumQuery)
        {
            _albumQuery = albumQuery;
        }

        public async Task<List<ShortPhotoDTO>> Handle(GetAlbumPhotosParameter query)
        {
            return await _albumQuery.GetAlbumPhotos(query);
        }
    }
}
