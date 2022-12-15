using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.UserInEvents
{
    public class UserInEvent
    {
        public UserInEvent(string userId, int eventId, bool isAdmin, bool isOwner)
        {
            UserId = userId;
            EventId = eventId;
            IsAdmin = isAdmin;
            IsOwner = isOwner;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOwner { get; set; }
    }
}
