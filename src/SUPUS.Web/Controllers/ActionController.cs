using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUPUS.Abstraction;

namespace SUPUS.Web.Controllers
{
    public class ActionController : Controller
    {
        private IDbContext _dbContext;

        public ActionController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Action
        public ActionResult Index()
        {
            return View();
        }

        // GET: Action/Present
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
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Action/Absent
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
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Action/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Action/Present
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Present(int id)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// POST: Action/Absent
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Absent(int id)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Action/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Action/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Action/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Action/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}