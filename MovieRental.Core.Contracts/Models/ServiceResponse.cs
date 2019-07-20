using MovieRental.Core.Contracts.Interfaces;
using System.Collections.Generic;

namespace MovieRental.Core.Contracts.Models
{
    public class ServiceResponse : IServiceResponse
    {
        public bool HasSucceeded { get; set; }

        public IList<string> Errors { get; set; }
    }
}
 