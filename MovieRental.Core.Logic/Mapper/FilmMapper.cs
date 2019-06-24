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
            cfg.CreateMap<IFilmModel, Film>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(f => f.Category.ToString()))
                .ForMember(dest => dest.Version, opt => opt.MapFrom(f => f.Version.ToString()));

            cfg.CreateMap<Film, IFilmModel>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(f => ConvertStringToFilmCategoryEnum(f.Category)))
               .ForMember(Dest => Dest.Version, opt => opt.MapFrom(f => ConvertStringToFilmVersionEnum(f.Version)));


            cfg.CreateMap<FilmModel, Film>()
                //.ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.MapFrom(f => f.Category.ToString()));


            cfg.CreateMap<Film, FilmModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(f => ConvertStringToFilmCategoryEnum(f.Category)));

        }).CreateMapper();

        private static FilmCategory ConvertStringToFilmCategoryEnum(string value)
        {
            return (FilmCategory) Enum.Parse(typeof(FilmCategory), value);
        }

        private static FilmVersion ConvertStringToFilmVersionEnum(string value)
        {
            return (FilmVersion)Enum.Parse(typeof(FilmVersion), value);
        }

    }

}
