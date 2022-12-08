using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class GetPhotosUseCase : IQueryHandler<GetPhotosParameter, List<PhotoDTO>>
    {
        private readonly IPhotoQuery _photoQuery;

        public GetPhotosUseCase(IPhotoQuery photoQuery)
        {
            _photoQuery = photoQuery;
        }

        public async Task<List<PhotoDTO>> Handle(GetPhotosParameter query)
        {
            return await _photoQuery.GetPhotos(query);
        }
    }
}
