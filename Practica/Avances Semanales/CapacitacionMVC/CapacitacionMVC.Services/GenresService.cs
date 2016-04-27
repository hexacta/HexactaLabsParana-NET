using System.Collections.Generic;
using System.Linq;
using CapacitacionMVC.Data;
using CapacitacionMVC.Entities;

namespace CapacitacionMVC.Services
{
    public class GenresService: IGenresService
    {
        private readonly DataContext _context;

        public GenresService()
        {
            this._context = new DataContext();
        }

        public IList<Genre> GetGenres()
        {
            return this._context.Genres.ToList();
        }

        public IList<Genre> SearchGenres(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return this._context.Genres.ToList();
            }

            return this._context.Genres.Where(p =>
                p.Name.ToLower().StartsWith(searchValue.ToLower().Trim()))
                .ToList();
        }

        public Genre GetGenreById(int genreId)
        {
            return this._context.Genres.Find(genreId);
        }
    }
}
