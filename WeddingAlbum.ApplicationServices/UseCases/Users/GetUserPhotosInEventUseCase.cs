using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class GetUserPhotosInEventUseCase : IQueryHandler<GetUserPhotosInEventParameter, List<ShortPhotoDTO>>
    {
        private readonly IUserQuery _userQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetUserPhotosInEventUseCase(IUserQuery userInEventQuery, ICurrentUserService currentUserService)
        {
            _userQuery = userInEventQuery;
            _currentUserService = currentUserService;
        }

        public async Task<List<ShortPhotoDTO>> Handle(GetUserPhotosInEventParameter query)
        {
            query.UserId = _currentUserService.UserId;
            return await _userQuery.GetUserPhotosInEvent(query);
        }
    }
}
