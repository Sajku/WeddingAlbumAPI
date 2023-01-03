using System;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
    }
}
