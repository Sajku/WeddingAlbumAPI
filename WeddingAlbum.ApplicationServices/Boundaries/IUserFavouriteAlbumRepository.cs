using System.Threading.Tasks;
using WeddingAlbum.Domain.UserFavouriteAlbums;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserFavouriteAlbumRepository
    {
        Task Add(UserFavouriteAlbum userFavouriteAlbum);
    }
}
