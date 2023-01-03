using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserEventsUseCase : IQueryHandler<GetUserEventsParameter, List<UserEventDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUserEventsUseCase(IUserQuery userInEventQuery)
        {
            _userQuery = userInEventQuery;
        }

        public async Task<List<UserEventDTO>> Handle(GetUserEventsParameter query)
        {
            return await _userQuery.GetUserEvents(query);
        }
    }
}
