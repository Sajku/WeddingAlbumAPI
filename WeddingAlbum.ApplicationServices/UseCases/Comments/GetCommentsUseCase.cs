using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Comments
{
    public class GetCommentsUseCase : IQueryHandler<GetCommentsParameter, List<CommentDTO>>
    {
        private readonly ICommentQuery _commentQuery;
        public GetCommentsUseCase(ICommentQuery commentQuery)
        {
            _commentQuery = commentQuery;
        }

        public async Task<List<CommentDTO>> Handle(GetCommentsParameter query)
        {
            return await _commentQuery.GetComments(query);
        }
    }
}
