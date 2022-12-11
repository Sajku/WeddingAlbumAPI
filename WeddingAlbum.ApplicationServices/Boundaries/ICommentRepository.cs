using System.Threading.Tasks;
using WeddingAlbum.Domain.Comments;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
    }
}
