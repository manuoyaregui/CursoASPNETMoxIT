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
            var customer = _context.Customers.SingleOrDefault( c => c.Id == id );
            
            if (customer == null) 
                return NotFound();

            return View(customer);
        }
    }

        
}
