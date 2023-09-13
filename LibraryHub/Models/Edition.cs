using LibraryHub.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryHub.Models
{
    public class Edition:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Edition Logo")]
        [Required(ErrorMessage = "Edition logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Edition Name")]
        [Required(ErrorMessage = "Edition name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Edition description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Book> Books { get; set; }
    }
}
