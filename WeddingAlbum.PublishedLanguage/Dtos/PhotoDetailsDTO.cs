using System;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class PhotoDetailsDTO
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }
    }
}
