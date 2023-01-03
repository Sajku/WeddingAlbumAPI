using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUsersUseCase : IQueryHandler<GetUsersParameter, List<UserDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUsersUseCase(IUserQuery userQuery)
        {
            _userQuery = userQuery;
        }
        public async Task<List<UserDTO>> Handle(GetUsersParameter query)
        {
            return await _userQuery.GetUsers();
        }
    }
}
