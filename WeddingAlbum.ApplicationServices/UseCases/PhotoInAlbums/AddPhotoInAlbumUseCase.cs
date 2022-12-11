using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.PhotoInAlbums;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.PhotoInAlbums
{
    public class AddPhotoInAlbumUseCase : ICommandHandler<AddPhotoInAlbumCommand>
    {
        private readonly IPhotoInAlbumRepository _photoInAlbumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPhotoInAlbumUseCase(IPhotoInAlbumRepository photoInAlbumRepository, IUnitOfWork unitOfWork)
        {
            _photoInAlbumRepository = photoInAlbumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddPhotoInAlbumCommand command)
        {
            var photoInAlbum = new PhotoInAlbum(
                command.AlbumId,
                command.PhotoId);
            await _photoInAlbumRepository.Add(photoInAlbum);
            await _unitOfWork.Save();
        }
    }
}
