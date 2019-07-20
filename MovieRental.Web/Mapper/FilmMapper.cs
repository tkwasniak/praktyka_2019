using AutoMapper;
using MovieRental.Core.Contracts.Models;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MovieRental.Web.Mapper
{
    internal class FilmMapper
    {
        internal static IMapper Mapping = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmViewModel, FilmModel>();
            cfg.CreateMap<FilmModel, FilmViewModel>();
        }).CreateMapper();

    }
}