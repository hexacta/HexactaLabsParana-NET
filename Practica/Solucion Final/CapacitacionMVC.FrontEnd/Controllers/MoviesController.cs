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
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesSvc;
        private readonly IGenresService _genresSvc;

        public MoviesController(IMoviesService moviesSvc, IGenresService genresSvc)
        {
            this._moviesSvc = moviesSvc;
            this._genresSvc = genresSvc;
        }

        //
        // GET: /Movies/movieName
        public ActionResult Index(string movieName)
        {
            var movies = this._moviesSvc.GetMovies();

            if (!string.IsNullOrEmpty(movieName))
            {
                ViewBag.MovieName = movieName;
            }

            return View(movies);
        }

        public ActionResult Create(string movieName)
        {
            if (!string.IsNullOrEmpty(movieName))
            {
                ViewBag.MovieName = movieName;
            }

            var model = new MovieCreateEditViewModel()
            {
                Genres = this._genresSvc.GetGenres()
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreateEditViewModel model, string submitCommand)
        {
            if (ModelState.IsValid)
            {
                this._moviesSvc.AddMovie(model.Movie);

                if (submitCommand.Equals("Save"))
                {
                    return RedirectToAction("Index", new { movieName = model.Movie.Name });
                }
                else
                {
                    return RedirectToAction("Create", new { movieName = model.Movie.Name });
                }
            }

            model.Genres = this._genresSvc.GetGenres();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new MovieCreateEditViewModel()
            {
                Genres = this._genresSvc.GetGenres(),
                Movie = this._moviesSvc.GetMovieById(id)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                this._moviesSvc.EditMovie(model.Movie);

                return RedirectToAction("Index");
            }

            model.Genres = this._genresSvc.GetGenres();

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            this._moviesSvc.DeleteMovie(id);

            return new EmptyResult();
        }
	}
}