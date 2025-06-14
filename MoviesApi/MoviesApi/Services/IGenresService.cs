﻿namespace MoviesApi.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> Add(Genre genre);
        Genre Update(Genre genre);
        Genre Delete(Genre id);
        Task<Genre> GetById(byte id);

        Task<bool> IsValidGenre(byte id);
         
    }
}
