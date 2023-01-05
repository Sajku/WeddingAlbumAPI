using System.Threading.Tasks;
using WeddingAlbum.Domain.PhotoInAlbums;
using WeddingAlbum.Domain.Photos;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IPhotoRepository
    {
        Task Add(Photo photo);

        Task Add(PhotoInAlbum photoInAlbum);

        Task<PhotoInAlbum> GetPhotoFromAlbum(int photoId, int albumId);

        void DeletePhotoFromAlbum(PhotoInAlbum photo);

        Task<Photo> GetPhoto(int photoId);

        void DeletePhoto(Photo photo);
    }
}
