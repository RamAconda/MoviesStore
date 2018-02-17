
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy",ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
        
        [Required]
        [Display(Name = "Number in stock")]
        [Range(1,30)]
        public int NumberInStock { get; set; }

        public GenreLkp GenreLkp { get; set; }

        [Required]
        public int GenreLkpId { get; set; }
    }
}
