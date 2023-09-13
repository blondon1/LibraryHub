﻿using LibraryHub.Data.Base;
using LibraryHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Data.Services
{
    public class PublishersService: EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext context) : base(context)
        {
        }
    }
}
