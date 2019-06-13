using MovieRental.Web.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Web.Models
{
    public class FilmViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long")]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2019, ErrorMessage = "Invalid date")]
        public int Year { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long")]
        public string Director { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long")]
        public string Language { get; set; }

        [Required]
        public FilmCategory Category{ get; set; }

        public string Notes { get; set; }
    }
}