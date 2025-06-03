using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;

namespace MoviesApi.Services
{

    public class MoviesService : IMoviesService
    {
        private readonly ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Add(Movie movie)
        {
             await _context.Movies.AddAsync(movie);
            _context.SaveChanges();

            return movie;
        }

        public Movie Delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();

            return movie;
        }

        public async Task<Movie> GetById(int id)
        {
           return await _context.Movies.Include(m => m.Genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetAll(byte genreId = 0)
        {
            return   await _context.Movies
                .Where(m => m.GenreId == genreId || genreId == 0)
                .OrderByDescending(m => m.Rate) 
                .Include(g => g.Genre).ToListAsync();

        }

        public Movie Update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}
