using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenreLkpManager
    {
        private readonly ApplicationDbContext _context;

        public GenreLkpManager(ApplicationDbContext context)
        {
            if(context == null)
                throw new Exception("context can't be initialized with null, It has to have a value");

            _context = context;
        }

        private void ThrowContextExceptionIfNull()
        {
            if (_context == null)
                throw new Exception("_context is null");
        }

        public IQueryable<GenreLkp> GetGenreLkps()
        {
            ThrowContextExceptionIfNull();

            return _context.GenreLkps;
        }

        public List<GenreLkp> GetGenreLkpsAsList()
        {
            return GetGenreLkps().ToList();
        }

        public GenreLkp GetGenreLkpById(int id)
        {
            return GetGenreLkps().SingleOrDefault(genre => genre.Id == id);
        }

        public GenreLkp AddGenreLkp(GenreLkp genreLkp)
        {
            if (genreLkp == null)
                return null;
            
            ThrowContextExceptionIfNull();

            return _context.GenreLkps.Add(genreLkp);
        }

        public GenreLkp UpdateGenreLkp(GenreLkp genreLkp)
        {
            if (genreLkp == null)
                return null;

            ThrowContextExceptionIfNull();

            var oldVersionGenreLkp = GetGenreLkpById(genreLkp.Id);
            oldVersionGenreLkp.Name = genreLkp.Name;

            return oldVersionGenreLkp;
        }

    }
}