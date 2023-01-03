using System.Collections.Generic;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetUserFavouriteAlbumsInEventParameter : IQuery<List<UserAlbumInEventDTO>>
    {
        public string UserId { get; set; }
        public int EventId { get; set; }
    }
}
