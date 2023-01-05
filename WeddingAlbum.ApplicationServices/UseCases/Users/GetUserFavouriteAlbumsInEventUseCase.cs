using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserFavouriteAlbumsInEventUseCase : IQueryHandler<GetUserFavouriteAlbumsInEventParameter, List<UserAlbumInEventDTO>>
    {
        private readonly IUserQuery _userQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetUserFavouriteAlbumsInEventUseCase(IUserQuery userInEventQuery, ICurrentUserService currentUserService)
        {
            _userQuery = userInEventQuery;
            _currentUserService = currentUserService;
        }

        public async Task<List<UserAlbumInEventDTO>> Handle(GetUserFavouriteAlbumsInEventParameter query)
        {
            query.UserId = _currentUserService.UserId;
            return await _userQuery.GetUserFavouriteAlbumsInEvent(query);
        }
    }
}
