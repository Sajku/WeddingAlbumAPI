namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class UserAlbumInEventDTO
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int PhotosNumber { get; set; }
        public string MainPhotoBase64 { get; set; }
        public bool IsPrivate { get; set; }
    }
}
