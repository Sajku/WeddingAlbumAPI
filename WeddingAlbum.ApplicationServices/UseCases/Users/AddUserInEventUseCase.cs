using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class AddUserInEventUseCase : ICommandHandler<AddUserInEventCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddUserInEventUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddUserInEventCommand command)
        {
            command.UserId ??= _currentUserService.UserId;

            var userInEvent = new UserInEvent(
                command.UserId,
                command.EventId,
                command.IsAdmin,
                command.IsOwner);
            await _userRepository.Add(userInEvent);
            await _unitOfWork.Save();
        }
    }
}
