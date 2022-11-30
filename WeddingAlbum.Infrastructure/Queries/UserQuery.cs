using System;
using System.Threading.Tasks;
using EnsureThat;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.Infrastructure.QueryBuilder;

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
    }
}
