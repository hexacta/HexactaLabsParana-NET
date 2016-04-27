using System;
using System.Collections.Generic;
using System.Linq;
using CapacitacionMVC.Data;
using CapacitacionMVC.Entities;

namespace CapacitacionMVC.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly DataContext _context;

        public MoviesService(DataContext context)
        {
            this._context = context;
        }

        public IList<Movie> GetMovies()
        {
            return this._context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return this._context.Movies.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            this._context.Movies.Add(movie);
            this._context.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            this._context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = this._context.Movies.Find(movieId);
            if (movie != null)
            {
                this._context.Movies.Remove(movie);
                this._context.SaveChanges();
            }
        }
    }
}
