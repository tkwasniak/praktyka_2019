using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Contracts
{
    public interface IFilmServiceResponse
    {
        bool HasSucceeded { get; set; }
        string Errors { get; set; }
    }
}
