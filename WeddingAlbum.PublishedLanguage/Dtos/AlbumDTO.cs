using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string UserId { get; set; }
        public int MainPhotoId { get; set; }
        public int EventId { get; set; }
    }
}
