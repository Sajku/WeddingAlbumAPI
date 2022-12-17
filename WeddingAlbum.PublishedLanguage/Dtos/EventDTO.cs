using System;

namespace WeddingAlbum.PublishedLanguage.Dtos
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Localization { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string GuestCode { get; set; }

        public string AdminCode { get; }
    }
}
