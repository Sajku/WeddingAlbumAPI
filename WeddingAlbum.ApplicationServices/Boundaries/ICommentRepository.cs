using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Comments;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
    }
}
