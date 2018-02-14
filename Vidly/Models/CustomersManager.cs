using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Vidly.Models
{
    public class CustomersManager
    {
        public static ApplicationDbContext Context {get; set; }


        public static IQueryable<Customer> GetCustomers()
        {
            if (Context == null)
            {
                throw new NullReferenceException("Database context is null");
            }
            return Context.Customers.Include(customer => customer.MembershipType);
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