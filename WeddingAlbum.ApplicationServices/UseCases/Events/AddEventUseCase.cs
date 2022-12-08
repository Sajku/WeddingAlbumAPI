using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Event;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Events
{
    public class AddEventUseCase : ICommandHandler<AddEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddEventUseCase(IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddEventCommand command)
        {
            var e = new Event(
                command.Name,
                command.Localization,
                command.Description,
                command.Date,
                command.OwnerUserId,
                command.GuestCode,
                command.AdminCode);
            await _eventRepository.Add(e);
            await _unitOfWork.Save();
        }
    }
}
