using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Web.Models
{
    public class FilmsViewModel
    {
        public IEnumerable<FilmViewModel> Films { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}