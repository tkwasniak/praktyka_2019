using FluentValidation;
using FluentValidation.Results;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using System;

namespace MovieRental.Core.Logic.Validators
{
    public class FilmValidator : AbstractValidator<IFilmModel>
    {
        public override ValidationResult Validate(ValidationContext<IFilmModel> context)
        {
            return (context.InstanceToValidate == null)
                ? new ValidationResult(new[] { new ValidationFailure("IFilmModel", "Object is null") })
                : base.Validate(context);
        }
        public FilmValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id cannot be negative");

            RuleFor(x => x.Title).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Field required")
                .Length(2, 50).WithMessage("Title must be between 2 and 50 characters");

            RuleFor(x => x.Release).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Field required")
                .Must(BeAValidDate).WithMessage("Release date must be greater than 1/1/1950");

            RuleFor(x => x.Director).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Field required")
                .Matches(@"^([A-z]+)\s([A-z]+)$").WithMessage("Invalid name");

            RuleFor(x => x.Country).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Field required")
                .Matches(@"^([A-z]+)(\s[A-z]+){0,2}$").WithMessage("Invalid language");

            RuleFor(x => x.Category).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Field required")
                .Must(BeAValidCategoryEnum).WithMessage("Invalid movie rating")
                .Must((x, category) => BeAValidRating(category, x.Rating)).WithMessage("Horror movie must be R or NC17");

            RuleFor(x => x.Rating).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Field required")
                .Must(BeAValidRatingEnum).WithMessage("Invalid movie rating");



        }

        private bool BeAValidRatingEnum(FilmRating rating)
        {
            if (Enum.IsDefined(typeof(FilmRating), rating))
            {
                return true;
            }
            return false;
        }

        private bool BeAValidCategoryEnum(FilmCategory rating)
        {
            if (Enum.IsDefined(typeof(FilmCategory), rating))
            {
                return true;
            }
            return false;
        }


        private bool BeAValidDate(DateTime? date)
        {
            if (date >= new DateTime(1950, 1, 1) && date <= DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private bool BeAValidRating(FilmCategory category, FilmRating rating)
        {
            if (category != FilmCategory.Horror)
            {
                return true;
            }
            if (rating == FilmRating.R || rating == FilmRating.NC17)
            {
                return true;
            }
            return false;
        }

    }
}
