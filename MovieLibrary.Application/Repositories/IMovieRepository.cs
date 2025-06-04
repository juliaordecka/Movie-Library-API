using MovieLibrary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Application.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> CreateAsync(Movie movie);
        Task<Movie?> GetByIdAsync(Guid id);
        Task<Movie?> GetBySlugAsync(string slug);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<bool> DeleteByIdAsync(Guid id);
        Task<bool> UpdateAsync(Movie movie);
    }
}
