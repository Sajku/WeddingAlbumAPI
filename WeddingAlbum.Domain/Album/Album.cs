using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.Photos;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Album
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string UserId { get; set; }
        public int MainPhotoId { get; set; }
        public int EventId { get; set; }
        public User User { get; set; }
        public Photo Photo { get; set; }
        public Event Event { get; set; }

        public Album(string name, bool isPrivate, string userId, int mainPhotoId, int eventId)
        {
            Name = name;
            IsPrivate = isPrivate;
            UserId = userId;
            MainPhotoId = mainPhotoId;
            EventId = eventId;
        }
    }
}
