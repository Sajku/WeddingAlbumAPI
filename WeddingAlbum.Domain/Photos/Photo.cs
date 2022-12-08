using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Photos
{
    public class Photo
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public Photo(string base64, string description, string userId)
        {
            Base64 = base64;
            Description = description;
            UserId = userId;
        }
    }
}
