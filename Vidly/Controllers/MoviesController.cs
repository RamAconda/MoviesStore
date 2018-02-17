using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = ModelManagerFactory.MoviesManager.GetMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = ModelManagerFactory.MoviesManager.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                GenreLkps = ModelManagerFactory.GenreLkpManager.GetGenreLkpsAsList()
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = ModelManagerFactory.MoviesManager.GetMovieById(id),
                GenreLkps = ModelManagerFactory.GenreLkpManager.GetGenreLkpsAsList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            // do some validation here

            if (movie.Id == 0) // new movie
            {
                ModelManagerFactory.MoviesManager.AddMovie(movie);
            }
            else // movie to update
            {
                ModelManagerFactory.MoviesManager.UpdateMovie(movie);
            }
            ModelManagerFactory.SaveChanges();

            return RedirectToAction("Index","Movies");
        }
    }
}