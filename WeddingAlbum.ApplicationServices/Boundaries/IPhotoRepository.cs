using System.Threading.Tasks;
using WeddingAlbum.Domain.Photos;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IPhotoRepository
    {
        Task Add(Photo photo);
    }
}
