
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            AddedDate = movie.AddedDate;
            NumberInStock = movie.NumberInStock;
            GenreLkpId = movie.GenreLkpId;
        }
        
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1,30)]
        public int? NumberInStock { get; set; }

        [Required]
        public int? GenreLkpId { get; set; }
        
        public IEnumerable<GenreLkp> GenreLkps { get; set; }

    }
}