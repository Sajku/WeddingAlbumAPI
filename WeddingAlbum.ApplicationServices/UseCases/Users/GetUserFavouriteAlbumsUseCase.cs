using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserFavouriteAlbumsUseCase : IQueryHandler<GetUserFavouriteAlbumsParameter, List<UserFavouriteAlbumDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUserFavouriteAlbumsUseCase(IUserQuery userQuery)
        {
            _userQuery = userQuery;
        }

        public async Task<List<UserFavouriteAlbumDTO>> Handle(GetUserFavouriteAlbumsParameter query)
        {
            return await _userQuery.GetUserFavouriteAlbums(query);
        }
    }
}
