using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Logic.Common
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> GetPaged<T>(this IEnumerable<T> data, int page, int pageSize)
        {
            return data.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
