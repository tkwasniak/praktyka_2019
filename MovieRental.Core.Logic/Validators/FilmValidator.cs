using FluentValidation;
using MovieRental.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Validators
{
    public class FilmValidator: AbstractValidator<IFilmModel>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Fild required");
            RuleFor(x => x.Title).Length(2, 50).WithMessage("Title must be between 2 and 50 characters");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Year).InclusiveBetween(1950, DateTime.Now.Year).WithMessage("Invalid year");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Director).Length(4, 50).WithMessage("Name must be between 4 and 50 characters");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Fild required");
            RuleFor(x => x.Language).Length(1, 50).WithMessage("Language must be between 1 and 50 characters");
            RuleFor(x => x.Category).NotNull().WithMessage("Field required");
            RuleFor(x => x.Version).NotNull().WithMessage("Field required");
        }
    }
}
