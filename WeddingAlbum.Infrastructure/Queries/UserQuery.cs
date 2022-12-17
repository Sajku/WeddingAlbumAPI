using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
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

        public async Task<User> GetUserById(string id)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<User>()
                .From("[User]")
                .Where("Id", id)
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
    }
}
