﻿using System.Collections.Generic;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.PublishedLanguage.Queries
{
    public class GetUserFavouriteAlbumsParameter : IQuery<List<UserFavouriteAlbumDTO>>
    {
    }
}
