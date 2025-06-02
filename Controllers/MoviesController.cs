using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Application.Repositories;

namespace Movie_library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }
    }
}
