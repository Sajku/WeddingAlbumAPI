using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class UserFavouriteAlbumQuery : IUserFavouriteAlbumQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public UserFavouriteAlbumQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<UserFavouriteAlbumDTO>> GetUserFavouriteAlbums(GetUserFavouriteAlbumsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserFavouriteAlbumDTO>()
                .From("UserFavouriteAlbum")
                .BuildQuery<UserFavouriteAlbumDTO>()
                .ExecuteToList();
        }
    }
}
