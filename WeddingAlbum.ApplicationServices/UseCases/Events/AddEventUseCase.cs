using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class AddEventUseCase : ICommandHandler<AddEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddEventUseCase(IEventRepository eventRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _eventRepository = eventRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddEventCommand command)
        {
            var e = new Event(
                command.Name,
                command.Localization,
                command.Description,
                command.Date,
                command.GuestCode,
                command.AdminCode);
            await _eventRepository.Add(e);
            await _unitOfWork.Save();

            var userId = _currentUserService.UserId;

            var userInEvent = new UserInEvent(
                userId,
                e.Id,
                true,
                true);
            await _userRepository.Add(userInEvent);
            await _unitOfWork.Save();
        }
    }
}
