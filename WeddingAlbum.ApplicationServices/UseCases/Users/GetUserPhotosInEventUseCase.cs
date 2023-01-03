using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserPhotosInEventUseCase : IQueryHandler<GetUserPhotosInEventParameter, List<ShortPhotoDTO>>
    {
        private readonly IUserQuery _userQuery;

        public GetUserPhotosInEventUseCase(IUserQuery userInEventQuery)
        {
            _userQuery = userInEventQuery;
        }

        public async Task<List<ShortPhotoDTO>> Handle(GetUserPhotosInEventParameter query)
        {
            return await _userQuery.GetUserPhotosInEvent(query);
        }
    }
}
