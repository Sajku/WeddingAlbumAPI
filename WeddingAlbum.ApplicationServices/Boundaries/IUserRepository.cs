using System.Threading.Tasks;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserRepository
    {
        Task Store(User user);
        Task<User> GetAsync(string id);
        Task<UserFavouriteAlbum> GetUserFavouriteAlbum(string userId, int id);

        Task Add(UserInEvent userInEvent);

        Task Add(UserFavouriteAlbum userFavouriteAlbum);

        void DeleteUserFavouriteAlbum(UserFavouriteAlbum id);
    }
}
