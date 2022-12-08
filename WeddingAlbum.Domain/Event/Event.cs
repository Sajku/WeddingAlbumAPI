using System;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Event
{
    public class Event
    {
        public Event(string name, string localization, string description, DateTime date, string ownerUserId, string guestCode, string adminCode)
        {
            Name = name;
            Localization = localization;
            Description = description;
            Date = date;
            OwnerUserId = ownerUserId;
            GuestCode = guestCode;
            AdminCode = adminCode;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Localization { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string OwnerUserId { get; set; }

        public User User { get; set; }

        public string GuestCode { get; set; }

        public string AdminCode { get; set; }
    }
}
