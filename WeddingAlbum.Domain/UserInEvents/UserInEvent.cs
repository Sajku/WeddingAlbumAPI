using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.UserInEvents
{
    public class UserInEvent
    {
        public UserInEvent(string userId, int eventId, bool isAdmin)
        {
            UserId = userId;
            EventId = eventId;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsAdmin { get; set; }
    }
}
