using WeddingAlbum.Domain.Albums;
using WeddingAlbum.Domain.Photos;

namespace WeddingAlbum.Domain.PhotoInAlbums
{
    public class PhotoInAlbum
    {
        public PhotoInAlbum(int albumId, int photoId)
        {
            AlbumId = albumId;
            PhotoId = photoId;
        }

        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
