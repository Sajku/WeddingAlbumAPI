using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddUserInEventCommand : ICommand
    {
        public string UserId { get; set; } //Temporary
        public int EventId { get; set; } //Temporary
        public bool IsAdmin { get; set; }
    }
}
