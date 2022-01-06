﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;

namespace VehicleWebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly VehicleDbContext DbContext;

        public VehicleModelController(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index()
        {
            return View(await DbContext.VehicleModels.ToListAsync());
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.VehicleMakes = new SelectList(DbContext.VehicleMakes, "Id", "Name");
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleMake", "Name", "Abrv")] VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await DbContext.AddAsync(vehicleModel);
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vehicleModel);
        }

        // GET: VehicleModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}