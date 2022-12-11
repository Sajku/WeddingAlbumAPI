using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class UserFavouriteAlbumDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AlbumId { get; set; }
    }
}
