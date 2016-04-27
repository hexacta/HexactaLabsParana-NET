using System.Collections.Generic;
using CapacitacionMVC.Entities;

namespace CapacitacionMVC.Services
{
    public interface IGenresService
    {
        IList<Genre> GetGenres();
        IList<Genre> SearchGenres(string searchValue);
        Genre GetGenreById(int genreId);
    }
}
