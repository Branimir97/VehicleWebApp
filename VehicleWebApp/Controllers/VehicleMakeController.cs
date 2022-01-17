﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.Models;
using VehicleWebAppService;

namespace VehicleWebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleService VehicleService;

        public VehicleMakeController(VehicleService vehicleService)
        {
            VehicleService = vehicleService;
        }
    
        // GET: VehicleMake
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["AbrvSortParm"] = sortOrder == "abrv_asc" ? "abrv_desc" : "abrv_asc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var vehicleMakes = VehicleService.GetVehicleMakes(
                    sortOrder, currentFilter, searchString, pageNumber);
            return View(vehicleMakes);
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vehicleMake = await VehicleService.GetVehicleMake(id);
            return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ViewResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name", "Abrv")] VehicleMake vehicleMake)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await VehicleService.AddVehicleMake(vehicleMake);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        // GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await VehicleService.GetVehicleMake(id);
            return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMakeToUpdate = await VehicleService.GetVehicleMake(id);
            if (await TryUpdateModelAsync(
                vehicleMakeToUpdate, "", v => v.Name, v => v.Abrv))
            {
                try
                {
                    await VehicleService.UpdateVehicleMake();
                    return RedirectToAction("Index");
                }
                catch(DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await VehicleService.GetVehicleMake(id);
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleMake = await VehicleService.GetVehicleMake(id);

            if(vehicleMake == null)
            {
                return NotFound();
            }
            try
            {
                await VehicleService.DeleteVehicleMake(id);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
