using System.Web.Mvc;

namespace XBoxRentals.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}