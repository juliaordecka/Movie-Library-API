﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Application.Repositories;
using MovieLibrary.Contracts.Requests;
using System.Reflection;
using MovieLibrary.Application.Models;
using Movie_library.Mapping;

namespace Movie_library.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }
        [HttpPost(ApiEndpoints.Movies.Create)]
        public async Task<IActionResult> Create([FromBody]CreateMovieRequest request)
        {
            var movie = request.MapToMovie();
            var result = await _movieRepository.CreateAsync(movie);
            return CreatedAtAction(nameof(Get), new {idOrSlug=movie.Id}, movie); //pokazuje location
            //return Created($"{ApiEndpoints.Movies.Create}/{movie.Id}", movie); //zamiast return movie nalezy  zmapowac "movie" do nowego obiektu MovieResponse i wlasnie go zwrocic 
        }
        //get jeden film
        [HttpGet(ApiEndpoints.Movies.Get)]
        public async Task<IActionResult> Get([FromRoute] string idOrSlug)
        {
            var movie = Guid.TryParse(idOrSlug, out var id) ? await _movieRepository.GetByIdAsync(id)
                : await _movieRepository.GetBySlugAsync(idOrSlug);

            if(movie == null)
            {
                return NotFound();
            }
            var response = movie.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Movies.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAllAsync();
            var response = movies.MapToResponse();
            return Ok(response);
        }
        [HttpPut(ApiEndpoints.Movies.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
        {
            var movie = request.MapToMovie(id);
            var updated = await _movieRepository.UpdateAsync(movie);
            if(!updated)
            {
                return NotFound();
            }
            var response = movie.MapToResponse();
            return Ok(response);
        }
        [HttpDelete(ApiEndpoints.Movies.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _movieRepository.DeleteByIdAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
