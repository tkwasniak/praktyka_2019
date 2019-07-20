using FluentValidation.Attributes;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Validators;
using System;

namespace MovieRental.Core.Contracts.Models
{
    public class FilmModel : IFilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Release { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public FilmCategory Category { get; set; }
        public FilmRating Rating { get; set; }
    }
}
