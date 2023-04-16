using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;


        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var viewModel = new AllCustomersViewModel { Customers = customers };
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault( c => c.Id == id );
            
            if (customer == null) 
                return NotFound();

            return View(customer);
        }

        

        public IActionResult New()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = memberShipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                
                customerInDB.Name = customer.Name;
                customerInDB.MembershipType = customer.MembershipType;
                customerInDB.Birthday = customer.Birthday;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }


            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return NotFound();


            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }

        
}
