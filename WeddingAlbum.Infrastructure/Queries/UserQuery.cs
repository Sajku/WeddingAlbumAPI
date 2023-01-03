using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public UserQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserDTO>()
                .From("[User]")
                .BuildQuery<UserDTO>()
                .ExecuteToList();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<User>()
                .From("[User]")
                .Where("Id", id)
                .BuildQuery<User>()
                .ExecuteToFirstElement();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<User>()
                .From("[User]")
                .Where("Login", login)
                .BuildQuery<User>()
                .ExecuteToFirstElement();
        }

        public async Task<List<UserFavouriteAlbumDTO>> GetUserFavouriteAlbums(GetUserFavouriteAlbumsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserFavouriteAlbumDTO>()
                .From("UserFavouriteAlbum")
                .BuildQuery<UserFavouriteAlbumDTO>()
                .ExecuteToList();
        }

        public async Task<List<UserInEventDTO>> GetUserInEvents(GetUserInEventsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserInEventDTO>()
                .From("UserInEvent")
                .BuildQuery<UserInEventDTO>()
                .ExecuteToList();
        }


        public async Task<List<UserEventDTO>> GetUserEvents(GetUserEventsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserEventDTO>()
                .From("VW_UserEvents")
                .Where("UserId", query.UserId)
                .BuildQuery<UserEventDTO>()
                .ExecuteToList();
        }

        public async Task<List<ShortPhotoDTO>> GetUserPhotosInEvent(GetUserPhotosInEventParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<ShortPhotoDTO>()
                .From("Photo")
                .Where("UserId", query.UserId)
                .Where("EventId", query.EventId)
                .BuildQuery<ShortPhotoDTO>()
                .ExecuteToList();
        }

        public async Task<List<UserAlbumInEventDTO>> GetUserFavouriteAlbumsInEvent(GetUserFavouriteAlbumsInEventParameter query)
        {
            var albums = await _sqlQueryBuilder
                .SelectAllProperties<UserAlbumInEventDTO>("PhotosNumber", "IsPrivate")
                .From("VW_FavAlbumsInEvent")
                .Where("UserId", query.UserId)
                .Where("EventId", query.EventId)
                .BuildQuery<UserAlbumInEventDTO>()
                .ExecuteToList();

            var albumsIds = albums.Select(x => x.AlbumId).ToList();

            var photosNumbers = await _sqlQueryBuilder
                .SelectAllProperties<AlbumPhotosNumberDTO>()
                .From("VW_AlbumsPhotosNumber")
                .WhereIn("AlbumId", albumsIds)
                .BuildQuery<AlbumPhotosNumberDTO>()
                .ExecuteToList();

            albums = albums.Select(album =>
            {
                album.PhotosNumber = photosNumbers.Where(photoNumber => photoNumber.AlbumId == album.AlbumId).Select(x => x.Number).FirstOrDefault();
                return album;
            }).ToList();

            return albums;
        }
    }
}
