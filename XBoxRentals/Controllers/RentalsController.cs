using System.Web.Mvc;

namespace XBoxRentals.Controllers
{
    [Authorize(Roles = "CanManageGames")]
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}