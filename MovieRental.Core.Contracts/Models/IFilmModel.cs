using MovieRental.Core.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Contracts.Models
{
    public interface IFilmModel
    {
        int Id { get; set; }
        string Title { get; set; }
        int Year { get; set; }
        string Director { get; set; }
        string Language { get; set; }
        FilmCategory Category { get; set; }
        FilmVersion Version { get; set; }


    }
}
