using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.PublishedLanguage.Dtos;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserFavouriteAlbumRepository
    {
        Task Add(UserFavouriteAlbum userFavouriteAlbum);
    }
}
