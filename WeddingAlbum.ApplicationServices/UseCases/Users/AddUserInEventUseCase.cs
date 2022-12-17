using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
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

        public AddUserInEventUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddUserInEventCommand command)
        {
            var userInEvent = new UserInEvent(
                command.UserId,
                command.EventId,
                command.IsAdmin);
            await _userRepository.Add(userInEvent);
            await _unitOfWork.Save();
        }
    }
}
