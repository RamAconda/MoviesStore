using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> Movies = new List<Movie>
        {
            new Movie {Id = 1, Name = "Fast & Feriou"},
            new Movie {Id = 2, Name = "Xxx return of Xander Cage"}
        };
        public ActionResult Index()
        {
            return View(Movies);
        }

        public ActionResult Details(int id)
        {
            var movie = Movies.Find(mov => mov.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
    }
}