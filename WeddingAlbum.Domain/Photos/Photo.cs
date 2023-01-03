using System;
using WeddingAlbum.Domain.Events;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Photos
{
    public class Photo
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        public Photo(string base64, string description, DateTime date, string userId, int eventId)
        {
            Base64 = base64;
            Description = description;
            Date = date;
            UserId = userId;
            EventId = eventId;
        }
    }
}
