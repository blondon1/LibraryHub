using LibraryHub.Data.Base;
using LibraryHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Data.Services
{
    public class CinemasService:EntityBaseRepository<Edition>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
