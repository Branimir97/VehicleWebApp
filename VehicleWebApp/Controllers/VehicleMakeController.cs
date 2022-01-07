﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using System.Linq;
using VehicleWebAppService.Models;
using System;

namespace VehicleWebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleDbContext DbContext;

        public VehicleMakeController(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: VehicleMake
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["AbrvSortParm"] = sortOrder == "abrv_asc" ? "abrv_desc" : "abrv_asc";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var vehicleMakes = from v in DbContext.VehicleMakes
                               select v;
            if(!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(v => v.Name.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "id_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleMakeId);
                    break;
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Name);
                    break;
                case "name_asc":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Name);
                    break;
                case "abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Abrv);
                    break;
                case "abrv_asc":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Abrv);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleMakeId);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<VehicleMake>.CreateAsync(vehicleMakes.AsNoTracking(), 
                        pageNumber ?? 1, pageSize));
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vehicleMake = await DbContext.VehicleMakes.Include(v => v.VehicleModels).
                                FirstOrDefaultAsync(v => v.VehicleMakeId == id);
            return View(vehicleMake);
        }

        // GET: VehicleMake/Create
        public ActionResult Create()
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
                    await DbContext.AddAsync(vehicleMake);
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vehicleMake);
        }

        // GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await DbContext.VehicleMakes.FindAsync(id);
            return View(vehicleMake);
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMakeToUpdate = await DbContext.VehicleMakes
                                        .FirstOrDefaultAsync(v => v.VehicleMakeId == id);
            if(await TryUpdateModelAsync(
                vehicleMakeToUpdate, "", v => v.Name, v => v.Abrv))
            {
                try
                {
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch(DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(vehicleMakeToUpdate);
        }

        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleMake = await DbContext.VehicleMakes.Include(v => v.VehicleModels).
                                            FirstOrDefaultAsync(v => v.VehicleMakeId == id);
            return View(vehicleMake);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleMake = await DbContext.VehicleMakes.FindAsync(id);

            if(vehicleMake == null)
            {
                return NotFound();
            }
            try
            {
                DbContext.VehicleMakes.Remove(vehicleMake);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vehicleMake);
        }
    }
}
