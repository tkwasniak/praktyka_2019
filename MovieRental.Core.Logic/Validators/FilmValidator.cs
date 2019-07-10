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
            RuleFor(x => x.Title).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Title).Length(2, 50).WithMessage("Title must be between 2 and 50 characters");
            RuleFor(x => x.Release).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Release).Must(isValidDate).WithMessage("Release date must be greater than 1/1/1950");
            RuleFor(x => x.Director).NotEmpty().WithMessage("Field required");
            RuleFor(x => x.Director).Length(4, 50).WithMessage("Name must be between 4 and 50 characters");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Fild required");
            RuleFor(x => x.Language).Length(1, 50).WithMessage("Language must be between 1 and 50 characters");
            RuleFor(x => x.Category).NotNull().WithMessage("Field required");
            RuleFor(x => x.Version).NotNull().WithMessage("Field required");
        }
        private bool isValidDate(DateTime? date)
        {
            if(date >= new DateTime(1950, 1, 1) && date <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
