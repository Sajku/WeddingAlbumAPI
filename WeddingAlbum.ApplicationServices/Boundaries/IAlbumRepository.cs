using System.Threading.Tasks;
using WeddingAlbum.Domain.Albums;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IAlbumRepository
    {
        Task Add(Album album);

        Task<Album> GetAlbum(int id);

        void DeleteAlbum(Album album);
    }
}
