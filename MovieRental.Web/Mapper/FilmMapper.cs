using AutoMapper;
using MovieRental.Core.Logic.Models;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Web.Mapper
{
    internal sealed class FilmMapper
    {
        internal static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmViewModel, FilmModel>();

        }).CreateMapper();
    }
}