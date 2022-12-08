using System;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddEventCommand : ICommand
    {
        public string Name { get; set; }

        public string Localization { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string OwnerUserId { get; set; } //Temporary

        public string GuestCode { get; set; }

        public string AdminCode { get; set; }
    }
}
