﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserFavouriteAlbumQuery
    {
        Task<List<UserFavouriteAlbumDTO>> GetUserFavouriteAlbums(GetUserFavouriteAlbumsParameter query);
    }
}
