using MovieRental.Core.Logic.Models;
using System.ComponentModel.DataAnnotations;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Enums;
using FluentValidation.Attributes;
using MovieRental.Core.Logic.Validators;

namespace MovieRental.Web.Models
{
    [Validator(typeof(FilmValidator))]
    public class FilmViewModel : IFilmModel
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