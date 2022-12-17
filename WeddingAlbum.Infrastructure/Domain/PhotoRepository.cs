using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.PhotoInAlbums;
using WeddingAlbum.Domain.Photos;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly WeddingAlbumContext _context;
        public PhotoRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Add(Photo photo)
        {
            await _context.Photos.AddAsync(photo);
        }

        public async Task Add(PhotoInAlbum photoInAlbum)
        {
            await _context.PhotoInAlbums.AddAsync(photoInAlbum);
        }
    }
}
