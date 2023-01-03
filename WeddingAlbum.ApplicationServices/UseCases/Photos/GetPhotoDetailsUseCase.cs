using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class GetPhotoDetailsUseCase : IQueryHandler<GetPhotoDetailsParameter, PhotoDetailsDTO>
    {
        private readonly IPhotoQuery _photoQuery;

        public GetPhotoDetailsUseCase(IPhotoQuery photoCommentQuery)
        {
            _photoQuery = photoCommentQuery;
        }

        public async Task<PhotoDetailsDTO> Handle(GetPhotoDetailsParameter query)
        {
            return await _photoQuery.GetPhotoDetails(query);
        }
    }
}
