using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Photos
{
    public class DeletePhotoFromAlbumUseCase : ICommandHandler<DeletePhotoFromAlbumCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoRepository _photoRepository;

        public DeletePhotoFromAlbumUseCase(IUnitOfWork unitOfWork, IPhotoRepository photoRepository)
        {
            _unitOfWork = unitOfWork;
            _photoRepository = photoRepository;
        }

        public async Task Handle(DeletePhotoFromAlbumCommand command)
        {
            var photo = await _photoRepository.GetPhotoFromAlbum(command.PhotoId, command.AlbumId);
            _photoRepository.DeletePhotoFromAlbum(photo);
            await _unitOfWork.Save();
        }
    }
}
