using CapacitacionMVC.Entities;
using CapacitacionMVC.FrontEnd.Models;
using CapacitacionMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapacitacionMVC.FrontEnd.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenresService _genresSvc;

        public GenresController(IGenresService genresSvc)
        {
            this._genresSvc = genresSvc;
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
        // GET: /Genres/
        public ActionResult Index()
        {
            GenresViewModel genresVM = new GenresViewModel() { Genres = this.Genres };

            return View(genresVM);
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

        private List<Genre> CreateGenresList()
        {
            return new List<Genre>
                {
                    new Genre() { Id = 1, Name = "Terror" },
                    new Genre() { Id = 2, Name = "Drama" },
                    new Genre() { Id = 2, Name = "Science Fiction" },
                    new Genre() { Id = 2, Name = "Comedy" }
                };
        }
	}
}