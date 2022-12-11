using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Comments;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class CommentRepository : ICommentRepository
    {
        private readonly WeddingAlbumContext _context;

        public CommentRepository(WeddingAlbumContext context)
        {
            _context = context;
        }
        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }
    }
}
