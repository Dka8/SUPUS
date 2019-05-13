using Microsoft.AspNetCore.Mvc;
using SUPUS.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUPUS.Abstraction;

namespace SUPUS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IDbContext _dbContext;

        public HomeController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var emp = new EmployeeViewInfo();
            ViewBag.Absents = _dbContext.GetAbsentEmployees();
            return View(emp);
        }

        // GET: Home/Present
        public ActionResult Present(int id)
        {
            try
            {
                // TODO: Add insert logic here
                ActionInfo info = new ActionInfo()
                {
                    Id = id,
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    Time = DateTime.Now.ToString("hh:mm:ss"),
                    IsPresent = true
                };

                _dbContext.EmployeeAction(info);
                return RedirectToAction(nameof(HomeController.Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Home/Absent
        public ActionResult Absent(int id)
        {
            try
            {
                // TODO: Add insert logic here
                ActionInfo info = new ActionInfo()
                {
                    Id = id,
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    Time = DateTime.Now.ToString("hh:mm:ss"),
                    IsPresent = false
                };

                _dbContext.EmployeeAction(info);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}