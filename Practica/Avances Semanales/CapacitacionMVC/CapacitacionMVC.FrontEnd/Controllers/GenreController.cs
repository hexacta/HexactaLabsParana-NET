using System.Collections.Generic;
using System.Web.Mvc;
using CapacitacionMVC.Entities;
using CapacitacionMVC.FrontEnd.Models;
using CapacitacionMVC.Services;

namespace CapacitacionMVC.FrontEnd.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenresService _genresSvc;

        public GenreController()
        {
            this._genresSvc = new GenresService();
        }

        private IList<Genre> Genres
        {
            get
            {
                // In memory objects
                //GenresViewModel genresVM = new GenresViewModel() { Genres = CreateGenresList() };

                // From database
                return this._genresSvc.GetGenres();
            }
        }

        //
        // GET: /Genre/
        public ActionResult Index()
        {
            var viewModel = new GenresViewModel { Genres = this.Genres };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(GenresViewModel genreVM)
        {
            if (string.IsNullOrWhiteSpace(genreVM.SearchValue))
            {
                genreVM.Genres = this.Genres;
            }
            else
            {
                // In memory objects
                //genreVM.Genres = this.Genres.Where(p =>
                //    p.Name.ToLower().StartsWith(genreVM.SearchValue.ToLower().Trim()))
                //    .ToList();

                // From database
                genreVM.Genres = this._genresSvc.SearchGenres(genreVM.SearchValue);
            }

            return View("Index", genreVM);
        }
	}
}