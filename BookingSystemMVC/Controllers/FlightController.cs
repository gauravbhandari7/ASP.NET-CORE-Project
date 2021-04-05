using BookingSystemInfrastructure;
using BookingSystemModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemMVC.Controllers
{
    public class FlightController : Controller
    {
        private readonly AppDBContext _db;
        public FlightController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData["DeleteMessage"] != null)
            {
                ViewBag.Message = TempData["DeleteMessage"];
            }

            if (TempData["EditMessage"] != null)
            {
                ViewBag.Message = TempData["EditMessage"];
            }

            if (TempData["CreateMessage"] != null)
            {
                ViewBag.Message = TempData["CreateMessage"];
            }

            IEnumerable<Flight> objList = _db.Flights;
            return (View(objList));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flight obj)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Add(obj);
                _db.SaveChanges();
                TempData["CreateMessage"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        //GET- Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = await _db.Flights.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Flight obj)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Update(obj);
                _db.SaveChanges();
                TempData["EditMessage"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            { 
            return View(obj);
            }
        }
        //GET-delete
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var obj = _db.Flights.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST-delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Flights.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Flights.Remove(obj);
                _db.SaveChanges();
                TempData["DeleteMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
