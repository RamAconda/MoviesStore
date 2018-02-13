using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Vidly.Models
{
    public class CustomersManager
    {
        private static ApplicationDbContext _context;


        public static IEnumerable<Customer> GetCustomers()
        {
            if (_context == null)
                _context = new ApplicationDbContext();

            return _context.Customers.Include(c => c.MembershipType);
        }

        public static List<Customer> GetCustomersAsList()
        {
            return GetCustomers().ToList();
        }

        public static Customer GetCustomerById(int id)
        {
            return GetCustomers().SingleOrDefault(c => c.Id == id);
        }
    }
}