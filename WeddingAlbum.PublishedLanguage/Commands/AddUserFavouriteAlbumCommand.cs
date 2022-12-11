using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddUserFavouriteAlbumCommand : ICommand
    {
        public string UserId { get; set; } //Temporary
        public int AlbumId { get; set; } //Temporary
    }
}
