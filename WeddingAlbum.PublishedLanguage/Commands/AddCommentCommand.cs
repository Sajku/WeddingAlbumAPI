using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddCommentCommand : ICommand
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int PhotoId { get; set; }
    }
}
