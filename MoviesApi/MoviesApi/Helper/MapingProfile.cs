using AutoMapper;
using MoviesApi.Dtos;

namespace MoviesApi.Helper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();
            CreateMap<CreateMovieDto, Movie>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
