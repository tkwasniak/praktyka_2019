﻿using FluentValidation.Attributes;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Validators;

namespace MovieRental.Core.Logic.Models
{
    [Validator(typeof(FilmValidator))]
    public class FilmModel : IFilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public FilmCategory Category { get; set; }
        public FilmVersion Version { get; set; }
    }
}
