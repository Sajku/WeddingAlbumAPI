using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IPhotoQuery
    {
        Task<List<PhotoDTO>> GetPhotos(GetPhotosParameter query);

        Task<List<PhotoInAlbumDTO>> GetPhotoInAlbums(GetPhotoInAlbumParameter query);

        Task<List<PhotoCommentDTO>> GetPhotoComments(GetPhotoCommentsParameter query);
    }
}
