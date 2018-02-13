using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Mohamed Ramadan"},
            new Customer {Id = 2, Name = "Mohamed Khalifa"},
            new Customer {Id = 3, Name = "Fatma Ramadan"},
            new Customer {Id = 4, Name = "Hazem Ramadan"}


        };

        public ActionResult Index()
        {
            var customers = CustomersManager.GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = CustomersManager.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}