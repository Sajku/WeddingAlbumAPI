using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.PhotoInAlbums;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class PhotoInAlbumRepository : IPhotoInAlbumRepository
    {
        private readonly WeddingAlbumContext _context;

        public PhotoInAlbumRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(PhotoInAlbum photoInAlbum)
        {
            await _context.PhotoInAlbums.AddAsync(photoInAlbum);
        }
    }
}
