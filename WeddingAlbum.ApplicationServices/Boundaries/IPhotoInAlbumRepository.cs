using System.Threading.Tasks;
using WeddingAlbum.Domain.PhotoInAlbums;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IPhotoInAlbumRepository
    {
        Task Add(PhotoInAlbum photoInAlbum);
    }
}
