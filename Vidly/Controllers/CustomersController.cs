
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

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

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = ModelManagerFactory.MembershipTypesManager.GetMembershipTypes()
            };
            return View(viewModel);
        }

        public ActionResult Create(Customer customer)
        {
            if (customer != null && ModelState.IsValid == false)
            {
                return View("New");
            }


            return View();
        }
    }
}