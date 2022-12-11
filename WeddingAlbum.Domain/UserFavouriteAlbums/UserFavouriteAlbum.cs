using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.Albums;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.UserFavouriteAlbums
{
    public class UserFavouriteAlbum
    {
        public UserFavouriteAlbum(string userId, int albumId)
        {
            UserId = userId;
            AlbumId = albumId;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
