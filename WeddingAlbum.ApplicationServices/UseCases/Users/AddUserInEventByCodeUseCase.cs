using System;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Users
{
    public class AddUserInEventByCodeUseCase : ICommandHandler<AddUserInEventByCodeCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddUserInEventByCodeUseCase(
            IEventRepository eventRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddUserInEventByCodeCommand command)
        {
            //var userId = _currentUserService.UserId;
            var userId = command.UserId;
            var result = await _eventRepository.CheckCode(command.Code);

            if (result.Id != 0)
            {
                var userInEvent = new UserInEvent(
                userId,
                result.Id,
                !result.IsGuest,
                false);
                await _userRepository.Add(userInEvent);
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
