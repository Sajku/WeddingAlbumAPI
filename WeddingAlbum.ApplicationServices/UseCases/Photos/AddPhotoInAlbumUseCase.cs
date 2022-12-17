using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.PhotoInAlbums;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class AddPhotoInAlbumUseCase : ICommandHandler<AddPhotoInAlbumCommand>
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPhotoInAlbumUseCase(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
        {
            _photoRepository = photoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddPhotoInAlbumCommand command)
        {
            var photoInAlbum = new PhotoInAlbum(
                command.AlbumId,
                command.PhotoId);
            await _photoRepository.Add(photoInAlbum);
            await _unitOfWork.Save();
        }
    }
}
