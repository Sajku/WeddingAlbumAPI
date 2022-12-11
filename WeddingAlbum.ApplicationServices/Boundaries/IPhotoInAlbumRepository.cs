using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.PhotoInAlbums;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IPhotoInAlbumRepository
    {
        Task Add(PhotoInAlbum photoInAlbum);
    }
}
