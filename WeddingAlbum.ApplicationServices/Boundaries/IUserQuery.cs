using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserQuery
    {
        Task<User> GetUserById(string id);

        Task<List<UserInEventDTO>> GetUserInEvents(GetUserInEventsParameter query);
        Task<List<UserEventDTO>> GetUserEvents(GetUserEventsParameter query);

        Task<List<UserFavouriteAlbumDTO>> GetUserFavouriteAlbums(GetUserFavouriteAlbumsParameter query);
    }
}
