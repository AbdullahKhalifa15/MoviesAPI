using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private readonly IMapper _mapper;

        private List<string> _allowedExtentions = new List<string> { ".png", ".jpg" };
        private long _maxAllowedPosterSize = 1048576; // max size for poster 1MB 

        public MoviesController(IMoviesService moviesService, IGenresService genresService, IMapper mapper)
        {
            _moviesService = moviesService;
            _genresService = genresService;
            _mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _moviesService.GetAll();

            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
          
                return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie = await _moviesService.GetById(id);
            if(movie == null)
            {
               return NotFound($"there is no movie with these ID {id}!");
            }

            var data = _mapper.Map<MovieDetailsDto>(movie);
            return Ok(data);
        }

        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreIdAsync(byte genreId)
        {
            var movies = await _moviesService.GetAll(genreId);

            if (movies.Count() == 0)
                return NotFound($"there is no movies with genreId {genreId}");

            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
            return Ok(data);


        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateMovieDto dto)
        {
            if (!_allowedExtentions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("Only .png and jpg images are allowed");
            
            if(dto.Poster.Length>_maxAllowedPosterSize)
                return BadRequest("Only 1MB size are allowed");

            var isValidGenreId = await _genresService.IsValidGenre(dto.GenreId);
            if (!isValidGenreId)
                return BadRequest("invalid genreId");
            

               // take poster from dto and copy it in an object
            using var datastream = new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);

            var movie = _mapper.Map<Movie>(dto);
            movie.Poster = datastream.ToArray();
          
            await _moviesService.Add(movie);

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, [FromForm] UpdateMovieDto dto)
        {
            var movie = await _moviesService.GetById(id);
            if (movie == null)
                return NotFound($"no movie was found with Id {id}");

            var isvalid = await _genresService.IsValidGenre(dto.GenreId);
            if (!isvalid)
                return BadRequest($"no genreId was found with Id {dto.GenreId}");

            if(dto.Poster != null)
            {
                if (!_allowedExtentions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Only .png and jpg images are allowed");

                if (dto.Poster.Length > _maxAllowedPosterSize)
                    return BadRequest("Only 1MB size are allowed");

                using var dataStream = new MemoryStream();
                await dto.Poster.CopyToAsync(dataStream);
               
                movie.Poster = dataStream.ToArray();

            }
           
            movie.Title = dto.Title;
            movie.StoreLine = dto.StoreLine;
            movie.Year = dto.Year;
            movie.Rate = dto.Rate;
            movie.GenreId = dto.GenreId;

            _moviesService.Update(movie);

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await _moviesService.GetById(id);
            if (movie == null)
                return NotFound($"no movie was found with Id {id}");

            _moviesService.Delete(movie);

            return Ok(movie);
        }
    }
}
