using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Contracts.Interfaces
{
    public interface IServiceResponse
    {
        bool HasSucceeded { get; set; }
        IList<string> Errors { get; set; }
    }
}
