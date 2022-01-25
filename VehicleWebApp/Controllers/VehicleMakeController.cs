using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.Models;
using VehicleWebAppService;
using VehicleWebApp.ViewModels;

namespace VehicleWebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleMakeService VehicleMakeService;

        public VehicleMakeController(VehicleMakeService vehicleMakeService)
        {
            VehicleMakeService = vehicleMakeService;
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
            VehicleMakeViewModel vehicleMakeViewModel = new()
            {
                VehicleMakes = await VehicleMakeService.GetVehicleMakesBy(
                    sortOrder, searchString, pageNumber)
            };
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            VehicleMakeViewModel vehicleMakeDetailsViewModel = new()
            {
                VehicleMake = await VehicleMakeService.GetVehicleMake(id)
            };
            return View(vehicleMakeDetailsViewModel);
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
                    await VehicleMakeService.AddVehicleMake(vehicleMake);
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
            VehicleMakeViewModel vehicleMakeDetailsViewModel = new()
            {
                VehicleMake = await VehicleMakeService.GetVehicleMake(id)
            }; 
            return View(vehicleMakeDetailsViewModel);
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMakeToUpdate = await VehicleMakeService.GetVehicleMake(id);
            if (await TryUpdateModelAsync(
                vehicleMakeToUpdate, "", v => v.Name, v => v.Abrv))
            {
                try
                {
                    await VehicleMakeService.UpdateVehicleMake();
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
            VehicleMakeViewModel vehicleMakeDetailsViewModel = new()
            {
                VehicleMake = await VehicleMakeService.GetVehicleMake(id)
            };
            return View(vehicleMakeDetailsViewModel);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleMake = await VehicleMakeService.GetVehicleMake(id);

            if(vehicleMake == null)
            {
                return NotFound();
            }
            try
            {
                await VehicleMakeService.DeleteVehicleMake(id);
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
