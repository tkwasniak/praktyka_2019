using AutoMapper;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Models;
using MovieRental.Data.DAL.Models;
using System;

namespace MovieRental.Core.Logic.Mapper
{
    internal sealed class FilmMapper
    {
        internal static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmModel, Film>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(f => f.Category.ToString()))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(f => f.Rating.ToString()));
            cfg.CreateMap<Film, FilmModel>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(f => ConvertStringToFilmCategoryEnum(f.Category)))
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(f => ConvertStringToFilmVersionEnum(f.Rating)));

        }).CreateMapper();


        private static FilmCategory ConvertStringToFilmCategoryEnum(string value)
        {
            return (FilmCategory) Enum.Parse(typeof(FilmCategory), value);
        }

        private static FilmRating ConvertStringToFilmVersionEnum(string value)
        {
            return (FilmRating)Enum.Parse(typeof(FilmRating), value);
        }

    }

}
