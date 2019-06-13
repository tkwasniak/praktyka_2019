using AutoMapper;
using MovieRental.Core.Logic.Models;
using MovieRental.Data.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Mapper
{
    internal sealed class FilmMapper
    {
        internal static IMapper Default = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FilmModel, Film>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.MapFrom(f => f.Category.ToString()));
        }).CreateMapper();
    }
}
