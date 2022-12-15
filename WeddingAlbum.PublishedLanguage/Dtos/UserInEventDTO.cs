namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class UserInEventDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
