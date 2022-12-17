﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Domain.UserFavouriteAlbums;
using WeddingAlbum.Domain.UserInEvents;
using WeddingAlbum.Domain.Users;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Infrastructure.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly WeddingAlbumContext _context;

        public UserRepository(WeddingAlbumContext context)
        {
            _context = context;
        }

        public async Task Store(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetAsync(string id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(UserInEvent userInEvent)
        {
            await _context.UserInEvents.AddAsync(userInEvent);
        }

        public async Task Add(UserFavouriteAlbum userFavouriteAlbum)
        {
            await _context.UserFavouriteAlbums.AddAsync(userFavouriteAlbum);
        }
    }
}
