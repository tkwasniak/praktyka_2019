using FluentValidation.Attributes;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Validators;
using MovieRental.Web.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Web.Models
{
    [Validator(typeof(FilmValidator))]
    public class FilmViewModel : IFilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? Release { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        [CategoryRatingRequired("Rating", ErrorMessage ="Horror movie has to be R or NC17")]
        public FilmCategory Category { get; set; }
        public FilmRating Rating { get; set; }


    }   
}