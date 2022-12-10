using System.Threading.Tasks;
using WeddingAlbum.Domain.Album;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IAlbumRepository
    {
        Task Add(Album album);
    }
}
