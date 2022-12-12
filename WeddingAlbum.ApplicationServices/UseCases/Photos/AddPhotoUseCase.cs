using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Photos;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class AddPhotoUseCase : ICommandHandler<AddPhotoCommand>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddPhotoUseCase(IPhotoRepository photoRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddPhotoCommand command)
        {
            string userId = _currentUserService.UserId;

            var photo = new Photo(
                command.Base64,
                command.Description,
                command.Date,
                command.UserId);

            await _photoRepository.Add(photo);
            await _unitOfWork.Save();
        }
    }
}
