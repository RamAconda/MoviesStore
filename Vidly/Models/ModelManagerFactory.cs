
namespace Vidly.Models
{
    public class ModelManagerFactory
    {
        private static ApplicationDbContext _context;
        private static MoviesManager _moviesManager;
        private static CustomersManager _customersManager;
        private static MembershipTypesManager _membershipTypesManager;

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

        public static MembershipTypesManager MembershipTypesManager
        {
            get
            {
                InstantiateContextIfNull();
                return _membershipTypesManager ?? (_membershipTypesManager = new MembershipTypesManager(_context));
            }
        }

        public static bool SaveChanges()
        {
            if (_context != null)
            {
                int affected = _context.SaveChanges();
                if (affected > 0)
                    return true;
            }
            InstantiateContextIfNull();
            return false;
        }
    }
}