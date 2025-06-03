namespace MoviesApi.Dtos
{
    public class BaseMovieDto
    {
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string StoreLine { get; set; }
        public byte GenreId { get; set; }
    }
}
