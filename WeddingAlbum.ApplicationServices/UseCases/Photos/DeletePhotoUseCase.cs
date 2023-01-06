using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class DeletePhotoUseCase : ICommandHandler<DeletePhotoCommand>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePhotoUseCase(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePhotoCommand command)
        {
            var photo = await _photoRepository.GetPhoto(command.PhotoId);
            _photoRepository.DeletePhoto(photo);
            await _unitOfWork.Save();
        }
    }
}
