using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserInEventUseCase : IQueryHandler<GetUserInEventsParameter, List<UserInEventDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUserInEventUseCase(IUserQuery userInEventQuery)
        {
            _userQuery = userInEventQuery;
        }

        public async Task<List<UserInEventDTO>> Handle(GetUserInEventsParameter query)
        {
            return await _userQuery.GetUserInEvents(query);
        }
    }
}
