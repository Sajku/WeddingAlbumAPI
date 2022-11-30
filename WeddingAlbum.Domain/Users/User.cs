using System;
using System.Linq;

namespace WeddingAlbum.Domain.Users
{
    public class User
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random = new Random();

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        public User() { }

        public User(string name, string lastName, string salt, string hash)
        {
            Name = name;
            LastName = lastName;
            Salt = salt;
            Hash = hash;
            Id = new string(Enumerable.Repeat(chars, 20)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
