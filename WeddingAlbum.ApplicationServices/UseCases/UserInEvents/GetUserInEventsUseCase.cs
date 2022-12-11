using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.UserInEvents
{
    public class GetUserInEventsUseCase : IQueryHandler<GetUserInEventsParameter, List<UserInEventDTO>>
    {
        private readonly IUserInEventQuery _userInEventQuery;

        public GetUserInEventsUseCase(IUserInEventQuery userInEventQuery)
        {
            _userInEventQuery = userInEventQuery;
        }

        public async Task<List<UserInEventDTO>> Handle(GetUserInEventsParameter query)
        {
            return await _userInEventQuery.GetUserInEvents(query);
        }
    }
}
