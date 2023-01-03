using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class GetPhotoCommentsUseCase : IQueryHandler<GetPhotoCommentsParameter, List<PhotoCommentDTO>>
    {
        private readonly IPhotoQuery _photoQuery;

        public GetPhotoCommentsUseCase(IPhotoQuery photoCommentQuery)
        {
            _photoQuery = photoCommentQuery;
        }

        public async Task<List<PhotoCommentDTO>> Handle(GetPhotoCommentsParameter query)
        {
            return await _photoQuery.GetPhotoComments(query);
        }
    }
}
