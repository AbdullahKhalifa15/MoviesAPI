﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAll();
            return Ok(genres);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateGenreDto dto)
        {
            var genre = new Genre() { Name = dto.Name };
            await _genresService.Add(genre);
            return Ok(genre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(byte id, [FromBody] CreateGenreDto dto)
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
            {
                return NotFound($"there is no genre with Id:{id}");
            }

            genre.Name = dto.Name;
          
            _genresService.Update(genre);

            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genresService.GetById(id);
            if (genre == null)
            {
                return NotFound($"there no genre with Id:{id}");
            }
            _genresService.Delete(genre);
           
            return Ok(genre);
        }
    }
}
