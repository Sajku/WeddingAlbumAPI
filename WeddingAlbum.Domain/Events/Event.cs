using System;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Events
{
    public class Event
    {
        public Event(string name, string localization, string description, DateTime date, string guestCode, string adminCode)
        {
            Name = name;
            Localization = localization;
            Description = description;
            Date = date;
            GuestCode = guestCode;
            AdminCode = adminCode;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Localization { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string GuestCode { get; set; }

        public string AdminCode { get; set; }
    }
}
