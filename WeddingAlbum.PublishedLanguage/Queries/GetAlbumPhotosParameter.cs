using System.Collections.Generic;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetAlbumPhotosParameter : IQuery<List<ShortPhotoDTO>>
    {
        public int AlbumId { get; set; }
    }
}
