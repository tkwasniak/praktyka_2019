using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Models
{
    class FilmModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public MovieCategory MovieCategory{ get; set; }
        public string Notes { get; set; }
    }
}
