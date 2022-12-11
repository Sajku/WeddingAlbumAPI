using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.UserFavouriteAlbums
{
    public class GetUserFavouriteAlbumsUseCase : IQueryHandler<GetUserFavouriteAlbumsParameter, List<UserFavouriteAlbumDTO>>
    {
        private readonly IUserFavouriteAlbumQuery _userFavouriteAlbumQuery;

        public GetUserFavouriteAlbumsUseCase(IUserFavouriteAlbumQuery userFavouriteAlbumQuery)
        {
            _userFavouriteAlbumQuery = userFavouriteAlbumQuery;
        }

        public async Task<List<UserFavouriteAlbumDTO>> Handle(GetUserFavouriteAlbumsParameter query)
        {
            return await _userFavouriteAlbumQuery.GetUserFavouriteAlbums(query);
        }
    }
}
