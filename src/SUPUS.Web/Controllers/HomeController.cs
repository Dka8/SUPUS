using Microsoft.AspNetCore.Mvc;

namespace SUPUS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}