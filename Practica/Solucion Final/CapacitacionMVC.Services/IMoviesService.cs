using CapacitacionMVC.Entities;
using System.Collections.Generic;

namespace CapacitacionMVC.Services
{
    public interface IMoviesService
    {
        IList<Movie> GetMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
        void DeleteMovie(int movieId);
    }
}
