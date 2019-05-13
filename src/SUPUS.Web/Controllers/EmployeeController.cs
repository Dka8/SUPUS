﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUPUS.Abstraction;

namespace SUPUS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IDbContext _dbContext;

        public EmployeeController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var users = _dbContext.GetEmployees();
            return View(users);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = _dbContext.GetEmployees().FirstOrDefault(e => e.Id == id);
            return View(employee);
        }

        // GET: Employee/Edit
        public ActionResult Edit(int id)
        {
            var shiftTypes = _dbContext.GetShiftTypes();
            ViewBag.Shifts = shiftTypes;
            var employee = _dbContext.GetEmployees().FirstOrDefault(e => e.Id == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                employee.Shift.Number 
                    = Int32.Parse(employee.Shift.Begin.Split().First());

                _dbContext.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Timetable/5
        public ActionResult TimeTable(int id)
        {
            var timetable = _dbContext.GetTimeTable(id);
            return View(timetable); 
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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