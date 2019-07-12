using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Models;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Web.ModelsBuilder
{
    public static class FilmModelBuilder
    {
        public static FilmViewModel GetFilmViewModel(FilmModel filmModel)
        {
            return FilmMapper.Default.Map<FilmModel, FilmViewModel>(filmModel);
        }
    }
}