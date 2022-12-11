using System;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int PhotoId { get; set; }
    }
}
