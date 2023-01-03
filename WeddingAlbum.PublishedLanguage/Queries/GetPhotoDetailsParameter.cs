using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetPhotoDetailsParameter : IQuery<PhotoDetailsDTO>
    {
        public int PhotoId { get; set; }
    }
}
