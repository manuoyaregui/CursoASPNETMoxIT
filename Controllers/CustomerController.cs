using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 0, Name = "Manuel"},
            new Customer { Id = 1, Name = "Tiago"},
            new Customer { Id = 2, Name = "Danilo"},
            new Customer { Id = 3, Name = "Valentín"}
        };

        public IActionResult Index()
        {
            var viewModel = new AllCustomersViewModel { Customers = customers };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var customer = customers[id];
            return View(customer);
        }
    }
}
