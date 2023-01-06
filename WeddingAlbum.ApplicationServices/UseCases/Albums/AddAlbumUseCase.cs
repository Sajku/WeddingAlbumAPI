using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.ApplicationServices.UseCases.Photos;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.Albums;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Albums
{
    public class AddAlbumUseCase : ICommandHandler<AddAlbumCommand>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public AddAlbumUseCase(IAlbumRepository albumRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _albumRepository = albumRepository;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task Handle(AddAlbumCommand command)
        {
            command.UserId ??= _currentUserService.UserId;

            var album = new Album(
                command.Name,       
                command.IsPrivate,
                command.UserId,
                command.MainPhotoId,
                command.EventId);

            await _albumRepository.Add(album);
            await _unitOfWork.Save();
        }
    }
}
