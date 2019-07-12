using AutoMapper;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Models;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MovieRental.Web.Mapper
{
    internal sealed class FilmMapper
    {
        internal static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmViewModel, FilmModel>()
                .ForMember(dest => dest.Release, opt => opt.MapFrom(f => ConvertStringToDateTime(f.Release)));
            cfg.CreateMap<FilmModel, FilmViewModel>()
                .ForMember(dest => dest.Release, opt => opt.MapFrom(f => f.Release.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }).CreateMapper();

        private static DateTime ConvertStringToDateTime(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}