using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserQuery
    {
        Task<List<UserDTO>> GetUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByLogin(string login);

        Task<List<UserInEventDTO>> GetUserInEvents(GetUserInEventsParameter query);
        Task<List<UserEventDTO>> GetUserEvents(GetUserEventsParameter query);

        Task<List<UserFavouriteAlbumDTO>> GetUserFavouriteAlbums(GetUserFavouriteAlbumsParameter query);

        Task<List<ShortPhotoDTO>> GetUserPhotosInEvent(GetUserPhotosInEventParameter query);

        Task<List<UserAlbumInEventDTO>> GetUserFavouriteAlbumsInEvent(GetUserFavouriteAlbumsInEventParameter query);
    }
}
