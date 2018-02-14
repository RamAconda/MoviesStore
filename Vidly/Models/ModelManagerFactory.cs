
namespace Vidly.Models
{
    public class ModelManagerFactory
    {
        private static ApplicationDbContext _context;
        private static MoviesManager _moviesManager;
        private static CustomersManager _customersManager;

        private static void InstantiateContextIfNull()
        {
            if(_context == null)
                _context = new ApplicationDbContext();
        }

        public static MoviesManager MoviesManager
        {
            get
            {
                InstantiateContextIfNull();
                return _moviesManager ?? (_moviesManager = new MoviesManager(_context));
            }
        }

        public static CustomersManager CustomersManager
        {
            get
            {
                InstantiateContextIfNull();
                return _customersManager ?? (_customersManager = new CustomersManager(_context));
            }
        }
    }
}