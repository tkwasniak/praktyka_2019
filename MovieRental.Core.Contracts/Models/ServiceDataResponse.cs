using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Interfaces;
using MovieRental.Core.Contracts.Models;
using System.Collections.Generic;

namespace MovieRental.Core.Logic.Services
{
    public class ServiceDataResponse<T> : IServiceResponse
    {
        public bool HasSucceeded { get; set; }

        public IList<string> Errors { get; set; }

        public T Data { get; set; }
    }
}