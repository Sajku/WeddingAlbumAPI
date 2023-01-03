using System.Collections.Generic;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetUserPhotosInEventParameter : IQuery<List<ShortPhotoDTO>>
    {
        public string UserId { get; set; }
        public int EventId { get; set; }
    }
}
