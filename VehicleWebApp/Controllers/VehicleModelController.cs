using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService;
using VehicleWebAppService.Models;

namespace VehicleWebApp.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService VehicleModelService;

        public VehicleModelController(VehicleModelService vehicleModelService)
        {
            VehicleModelService = vehicleModelService;
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["VehicleMakeNameSortParm"] =
                sortOrder == "veh_make_asc" ? "veh_make_desc" : "veh_make_asc";
            ViewData["VehicleMakeAbrvSortParm"] =
                sortOrder == "veh_abrv_asc" ? "veh_abrv_desc" : "veh_abrv_asc";
            ViewData["ModelSortParm"] =
                sortOrder == "model_asc" ? "model_desc" : "model_asc";
            ViewData["AbrvSortParm"] =
                sortOrder == "abrv_asc" ? "abrv_desc" : "abrv_asc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var vehicleModels = await VehicleModelService.GetVehicleModelsBy(
                    sortOrder, searchString, pageNumber);
            return View(vehicleModels);
            }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vehicleModel = await VehicleModelService.GetVehicleModel(id);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.VehicleMakes = new SelectList(await VehicleModelService.
                    GetAllVehicleModels(), "VehicleMakeId", "Abrv");
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleMakeId", "Name", "Abrv")] 
                            VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await VehicleModelService.AddVehicleModel(vehicleModel);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await VehicleModelService.GetVehicleModel(id);
            ViewBag.VehicleMakes = new SelectList(await VehicleModelService.GetAllVehicleModels(),
                        "VehicleMakeId", "Abrv");

            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleModelToUpdate = await VehicleModelService.GetVehicleModel(id);
            if (await TryUpdateModelAsync(
                vehicleModelToUpdate, "", v => v.VehicleMakeId, v => v.Name, v => v.Abrv))
            {
                try
                {
                    await VehicleModelService.UpdateVehicleModel();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await VehicleModelService.GetVehicleModel(id);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleModel = await VehicleModelService.GetVehicleModel(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }
            try
            {
                await VehicleModelService.DeleteVehicleModel(id);
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
