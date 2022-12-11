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
    public class UserInEventQuery : IUserInEventQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;
        public UserInEventQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<UserInEventDTO>> GetUserInEvents(GetUserInEventsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<UserInEventDTO>()
                .From("UserInEvent")
                .BuildQuery<UserInEventDTO>()
                .ExecuteToList();
        }
    }
}
