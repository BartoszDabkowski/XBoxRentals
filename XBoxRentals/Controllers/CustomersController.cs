using System.Linq;
using System.Web.Mvc;
using XBoxRentals.Models;
using XBoxRentals.ViewModels;

namespace XBoxRentals.Controllers
{
    [Authorize(Roles = "CanManageGames")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Games
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customerInDb = _context.Customers
                .SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return HttpNotFound();

            customerInDb.MembershipType = _context.MembershipTypes
                .SingleOrDefault(c => c.Id == customerInDb.MembershipTypeId);

            return View(customerInDb);
        }

        //public ActionResult ReadOnlyList()
        //{
        //    return View();
        //}

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(g => g.Id == id);

            if (customerInDb == null)
                return HttpNotFound();

            var newCustomerViewModel = new CustomerFormViewModel(customerInDb)
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var newCustomerFormViewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", newCustomerFormViewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(g => g.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToEmail = customer.IsSubscribedToEmail;
            }

            _context.SaveChanges();

            return RedirectToAction("List", "Customers");
        }
    }
}