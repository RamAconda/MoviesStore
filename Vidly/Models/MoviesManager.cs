using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Vidly.Models
{
    public class MoviesManager
    {
        private readonly ApplicationDbContext _context;

        public MoviesManager(ApplicationDbContext context)
        {
            //check that the parameter is not null,
            //because if it's null and the _context not null 
            //then not to be assigned to null
            if (context == null)
            {
                throw new Exception("_context can't be assigned to null, it needs to be instantiated.");
            }
            _context = context;
        }

        private void ThrowContextExceptionIfNull()
        {
            if (_context == null)
            {
                throw new Exception("_context is null, can't be used.");
            }
        }

        public IQueryable<Movie> GetMovies()
        {
            ThrowContextExceptionIfNull();
            return _context.Movies.Include(movie => movie.GenreLkp);
        }

        public List<Movie> GetMoviesAsList()
        {
            return GetMovies().ToList();
        }

        public Movie GetMovieById(int id)
        {
            return GetMovies().SingleOrDefault(movie => movie.Id == id);
        }

        public Movie AddMovie(Movie movie)
        {
            if (movie == null)
                return null;

            ThrowContextExceptionIfNull();

            return _context.Movies.Add(movie);
        }

        public Movie UpdateMovie(Movie movie)
        {
            if (movie == null)
            {
                return null;
            }
            ThrowContextExceptionIfNull();

            Movie oldVersionMovie = GetMovieById(movie.Id);
            if (oldVersionMovie != null)
            {
                oldVersionMovie.Name = movie.Name;
                oldVersionMovie.ReleaseDate = movie.ReleaseDate;
                oldVersionMovie.AddedDate = movie.AddedDate;
                oldVersionMovie.GenreLkpId = movie.GenreLkpId;
                oldVersionMovie.NumberInStock = movie.NumberInStock;

                return oldVersionMovie;
            }
            return null;
        }
    }
}