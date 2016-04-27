using CapacitacionMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacitacionMVC.Services
{
    public interface IGenresService
    {
        IList<Genre> GetGenres();
        IList<Genre> SearchGenres(string searchValue);
        Genre GetGenreById(int genreId);
    }
}
