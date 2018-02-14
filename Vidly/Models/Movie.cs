﻿
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
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
        
        [Required]
        public int NumberInStock { get; set; }

        public GenreLkp GenreLkp { get; set; }
        public int GenreLkpId { get; set; }
    }
}
