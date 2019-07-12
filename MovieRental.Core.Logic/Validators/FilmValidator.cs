using FluentValidation;
using MovieRental.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Validators
{
    public class FilmValidator: AbstractValidator<IFilmModel>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Title).Length(2, 50).WithMessage("Title must be between 2 and 50 characters");
            //RuleFor(x => x.Release).NotEmpty().WithMessage("Field required");
            //RuleFor(x => x.Release).Must(BeAValidDate).WithMessage("Release date must be greater than 1/1/1950");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Director).Matches(@"^([A-z]+)\s([A-z]+)$").WithMessage("Invalid name");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Fild required");
            RuleFor(x => x.Country).Matches(@"^([A-z]+)$").WithMessage("Invalid language");
            RuleFor(x => x.Category).NotNull().WithMessage("Field required");
            RuleFor(x => x.Rating).NotNull().WithMessage("Field required");
        }
        private bool BeAValidDate(DateTime? date)
        {
            if (date >= new DateTime(1950, 1, 1) && date <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
