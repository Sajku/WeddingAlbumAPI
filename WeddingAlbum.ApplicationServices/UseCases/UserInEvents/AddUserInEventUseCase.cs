using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.UserInEvents
{
    public class AddUserInEventUseCase : ICommandHandler<AddUserInEventCommand>
    {
        private readonly IUserInEventRepository _userInEventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserInEventUseCase(IUserInEventRepository userInEventRepository, IUnitOfWork unitOfWork)
        {
            _userInEventRepository = userInEventRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddUserInEventCommand command)
        {
            var userInEvent = new UserInEvent(
                command.UserId,
                command.EventId,
                command.IsAdmin,
                command.IsOwner);
            await _userInEventRepository.Add(userInEvent);
            await _unitOfWork.Save();
        }
    }
}
