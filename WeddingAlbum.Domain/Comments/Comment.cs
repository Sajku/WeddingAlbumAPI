using System;
using WeddingAlbum.Domain.Photos;
using WeddingAlbum.Domain.Users;

namespace WeddingAlbum.Domain.Comments
{
    public class Comment
    {
        public Comment(string content, DateTime date, int likesCount, string userId, int photoId)
        {
            Content = content;
            Date = date;
            LikesCount = likesCount;
            UserId = userId;
            PhotoId = photoId;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int LikesCount { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
