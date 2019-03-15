using Microsoft.AspNetCore.Mvc;
using SUPUS.Abstraction;

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