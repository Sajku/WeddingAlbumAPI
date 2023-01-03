﻿using System;
using WeddingAlbum.Common.CQRS;

namespace WeddingAlbum.PublishedLanguage.Commands
{
    public class AddPhotoCommand : ICommand
    {
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } // TEMPORARY
        public int EventId { get; set; }
    }
}
