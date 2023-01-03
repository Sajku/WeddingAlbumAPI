using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class DeleteUserFavouriteAlbumUseCase : ICommandHandler<DeleteUserFavouriteAlbumCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserFavouriteAlbumUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserFavouriteAlbumCommand command)
        {
            var album = await _userRepository.GetUserFavouriteAlbum(command.UserId, command.AlbumId);
            _userRepository.DeleteUserFavouriteAlbum(album);
            await _unitOfWork.Save();
        }
    }
}
