﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IAlbumQuery
    {
        Task<List<AlbumDTO>> GetAlbums(GetAlbumsParameter query);
        Task<List<ShortPhotoDTO>> GetAlbumPhotos(GetAlbumPhotosParameter query);
    }
}
