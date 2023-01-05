using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class DeletePhotoFromAlbumCommand : ICommand
    {
        public int PhotoId { get; set; }

        public int AlbumId { get; set; }
    }
}
