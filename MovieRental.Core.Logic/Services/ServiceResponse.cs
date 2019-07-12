using MovieRental.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Services
{
    public class ServiceResponse : IFilmServiceResponse
    {
        public bool HasSucceeded { get; set; }
        public string Errors { get; set; }
    }
}
