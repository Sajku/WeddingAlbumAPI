﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.Boundaries
{
    public interface IUserInEventQuery
    {
        Task<List<UserInEventDTO>> GetUserInEvents(GetUserInEventsParameter query);
    }
}
