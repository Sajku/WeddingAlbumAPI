using System;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddCommentCommand : ICommand
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } //Temporary
        public int PhotoId { get; set; }
    }
}
