using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

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
    }
}