using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult Index()
        {
            var customers = ModelManagerFactory.CustomersManager.GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = ModelManagerFactory.CustomersManager.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}