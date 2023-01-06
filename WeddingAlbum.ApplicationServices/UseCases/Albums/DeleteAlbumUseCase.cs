using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.Domain;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.ApplicationServices.UseCases.Albums
{
    public class DeleteAlbumUseCase : ICommandHandler<DeleteAlbumCommand>
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAlbumUseCase(IAlbumRepository albumRepository, IUnitOfWork unitOfWork)
        {
            _albumRepository = albumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAlbumCommand command)
        {
            var album = await _albumRepository.GetAlbum(command.AlbumId);
            _albumRepository.DeleteAlbum(album);
            await _unitOfWork.Save();
        }
    }
}
