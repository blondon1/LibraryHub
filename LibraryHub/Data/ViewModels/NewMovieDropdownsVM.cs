using LibraryHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
            Producers = new List<Publisher>();
            Cinemas = new List<Edition>();
            Author = new List<Author>();
        }

        public List<Publisher> Producers { get; set; }
        public List<Edition> Cinemas { get; set; }
        public List<Author> Author { get; set; }
    }
}
