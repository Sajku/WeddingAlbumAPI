using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class CommentQuery : ICommentQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;
        public CommentQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<CommentDTO>> GetComments(GetCommentsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<CommentDTO>()
                .From("Comment")
                .BuildQuery<CommentDTO>()
                .ExecuteToList();
        }
    }
}
