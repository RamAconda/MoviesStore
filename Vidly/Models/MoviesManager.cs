using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class MoviesManager
    {
        public static ApplicationDbContext Context { get; set; }

        public static IQueryable<Movie> GetMovies()
        {
            if (Context == null)
            {
                throw new NullReferenceException("Database context is null");
            }
            return Context.Movies.Include(movie => movie.GenreLkp);
        }

        public static List<Movie> GetMoviesAsList()
        {
            return GetMovies().ToList();
        }

        public static Movie GetMovieById(int id)
        {
            return GetMovies().SingleOrDefault(movie => movie.Id == id);
        }


    }
}