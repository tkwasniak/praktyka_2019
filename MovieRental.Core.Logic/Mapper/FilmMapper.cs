using AutoMapper;
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
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.MapFrom(f => f.Category.ToString()));

            cfg.CreateMap<Film, FilmModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(f => ConvertStringToEnum(f.Category)));

        }).CreateMapper();

        private static FilmCategory ConvertStringToEnum(string value)
        {
            return (FilmCategory) Enum.Parse(typeof(FilmCategory), value);
        }

    }

}
