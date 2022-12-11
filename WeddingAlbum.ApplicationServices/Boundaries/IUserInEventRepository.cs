using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.Domain.UserInEvents;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserInEventRepository
    {
        Task Add(UserInEvent userInEvent);
    }
}
