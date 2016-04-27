using CapacitacionMVC.Data;
using System.Collections.Generic;
using System.Linq;

namespace CapacitacionMVC.Services
{
    public class GenresService : IGenresService
    {
        private readonly DomainContext _context;

        public GenresService(DomainContext context)
        {
            this._context = context;
        }

        public IList<Entities.Genre> GetGenres()
        {
            return this._context.Genres.ToList();
        }

        public IList<Entities.Genre> SearchGenres(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return this._context.Genres.ToList();
            }
            
            return this._context.Genres.Where(p =>
                p.Name.ToLower().StartsWith(searchValue.ToLower().Trim()))
                .ToList();
        }

        public Entities.Genre GetGenreById(int genreId)
        {
            return this._context.Genres.Find(genreId);
        }
    }
}
