using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class DeleteUserFavouriteAlbumUseCase : ICommandHandler<DeleteUserFavouriteAlbumCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserFavouriteAlbumUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(DeleteUserFavouriteAlbumCommand command)
        {
            command.UserId ??= _currentUserService.UserId;
            var album = await _userRepository.GetUserFavouriteAlbum(command.UserId, command.AlbumId);
            _userRepository.DeleteUserFavouriteAlbum(album);
            await _unitOfWork.Save();
        }
    }
}
