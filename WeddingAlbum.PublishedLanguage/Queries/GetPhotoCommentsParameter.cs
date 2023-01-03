using System.Collections.Generic;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetPhotoCommentsParameter : IQuery<List<PhotoCommentDTO>>
    {
        public int PhotoId { get; set; }
    }
}
