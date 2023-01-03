using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserFavouriteAlbumsInEventUseCase : IQueryHandler<GetUserFavouriteAlbumsInEventParameter, List<UserAlbumInEventDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUserFavouriteAlbumsInEventUseCase(IUserQuery userInEventQuery)
        {
            _userQuery = userInEventQuery;
        }

        public async Task<List<UserAlbumInEventDTO>> Handle(GetUserFavouriteAlbumsInEventParameter query)
        {
            return await _userQuery.GetUserFavouriteAlbumsInEvent(query);
        }
    }
}
