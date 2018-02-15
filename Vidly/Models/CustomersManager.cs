using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Vidly.Models
{
    public class CustomersManager
    {
        private readonly ApplicationDbContext _context;

        public CustomersManager(ApplicationDbContext context)
        {
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

        public IQueryable<Customer> GetCustomers()
        {
            ThrowContextExceptionIfNull();
            return _context.Customers.Include(customer => customer.MembershipType);
        }

        public List<Customer> GetCustomersAsList()
        {
            return GetCustomers().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return GetCustomers().SingleOrDefault(customer => customer.Id == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            ThrowContextExceptionIfNull();

            //add the customer if _context is not null
            return _context.Customers.Add(customer);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            ThrowContextExceptionIfNull();

            Customer oldVersionCustomer = GetCustomerById(customer.Id);
            if (oldVersionCustomer != null)
            {
                oldVersionCustomer.Name = customer.Name;
                oldVersionCustomer.DateOfBirth = customer.DateOfBirth;
                oldVersionCustomer.MembershipTypeId = customer.MembershipTypeId;

                return oldVersionCustomer;
            }

            return null;
        }
    }
}