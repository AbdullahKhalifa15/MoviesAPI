namespace MoviesApi.Dtos
{
    public class UpdateMovieDto : BaseMovieDto
    {

        public IFormFile? Poster { get; set; }
    }
}
