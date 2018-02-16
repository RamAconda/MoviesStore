
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = ModelManagerFactory.MembershipTypesManager.GetMembershipTypes()
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = ModelManagerFactory.CustomersManager.GetCustomerById(id),
                MembershipTypes = ModelManagerFactory.MembershipTypesManager.GetMembershipTypes()
            };

            return View(viewModel);
        }

        public ActionResult CustomerForm(Customer customer)
        {

            if (customer.Id == 0)
            {
                if (ModelState.IsValid == false)
                {
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = customer,
                        MembershipTypes = ModelManagerFactory.MembershipTypesManager.GetMembershipTypesAsList()
                    };
                    return View("New", viewModel);
                }
                ModelManagerFactory.CustomersManager.AddCustomer(customer);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = customer,
                        MembershipTypes = ModelManagerFactory.MembershipTypesManager.GetMembershipTypesAsList()
                    };
                    return View("Edit", viewModel);
                }
                ModelManagerFactory.CustomersManager.UpdateCustomer(customer);
            }

            ModelManagerFactory.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}