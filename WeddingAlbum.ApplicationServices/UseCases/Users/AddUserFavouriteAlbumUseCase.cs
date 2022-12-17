using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class AddUserFavouriteAlbumUseCase : ICommandHandler<AddUserFavouriteAlbumCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserFavouriteAlbumUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddUserFavouriteAlbumCommand command)
        {
            var userFavouriteAlbum = new UserFavouriteAlbum(
                command.UserId,
                command.AlbumId);
            await _userRepository.Add(userFavouriteAlbum);
            await _unitOfWork.Save();
        }
    }
}
