using Microsoft.EntityFrameworkCore;
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

        public void DeletePhoto(Photo photo)
        {
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public void DeletePhotoFromAlbum(PhotoInAlbum photo)
        {
            _context.PhotoInAlbums.Remove(photo);
            _context.SaveChanges();
        }

        public async Task<Photo> GetPhoto(int photoId)
        {
            return await _context.Photos
                .SingleOrDefaultAsync(p => p.Id == photoId);
        }

        public async Task<PhotoInAlbum> GetPhotoFromAlbum(int photoId, int albumId)
        {
            return await _context.PhotoInAlbums
                .SingleOrDefaultAsync(p => p.PhotoId == photoId && p.AlbumId == albumId);
        }
    }
}
