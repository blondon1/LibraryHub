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
            Publishers = new List<Publisher>();
            Edition = new List<Edition>();
            Author = new List<Author>();
        }

        public List<Publisher> Publishers { get; set; }
        public List<Edition> Edition { get; set; }
        public List<Author> Author { get; set; }
    }
}
