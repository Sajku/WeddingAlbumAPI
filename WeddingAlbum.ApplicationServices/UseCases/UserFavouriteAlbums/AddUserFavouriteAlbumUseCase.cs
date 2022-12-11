using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.UserFavouriteAlbums
{
    public class AddUserFavouriteAlbumUseCase : ICommandHandler<AddUserFavouriteAlbumCommand>
    {
        private readonly IUserFavouriteAlbumRepository _userFavouriteAlbumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserFavouriteAlbumUseCase(IUserFavouriteAlbumRepository userFavouriteAlbumRepository, IUnitOfWork unitOfWork)
        {
            _userFavouriteAlbumRepository = userFavouriteAlbumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddUserFavouriteAlbumCommand command)
        {
            var userFavouriteAlbum = new UserFavouriteAlbum(
                command.UserId,
                command.AlbumId);
            await _userFavouriteAlbumRepository.Add(userFavouriteAlbum);
            await _unitOfWork.Save();
        }
    }
}
