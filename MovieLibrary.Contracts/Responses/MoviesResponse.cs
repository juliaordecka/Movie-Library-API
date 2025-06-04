using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Contracts.Responses
{
    public class MoviesResponse
    {
        public required IEnumerable<MoviesResponse> Items { get; init; } = Enumerable.Empty<MoviesResponse>();
    }
}
