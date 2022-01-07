using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

            var vehicleModels = from v in DbContext.VehicleModels
                                select v;
            if(!string.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.VehicleMake.Name.Contains(searchString)
                                    || v.VehicleMake.Abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleModelId);
                    break;
                case "veh_make_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleMake.Name);
                    break;
                case "veh_make_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleMake.Name);
                    break;
                case "veh_abrv_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleMake.Abrv);
                    break;
                case "veh_abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleMake.Abrv);
                    break;
                case "model_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Name);
                    break;
                case "model_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Name);
                    break;
                case "abrv_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Abrv);
                    break;
                case "abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Abrv);
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleModelId);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<VehicleModel>.CreateAsync(
                vehicleModels.Include(v => v.VehicleMake).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var vehicleModel = await DbContext.VehicleModels.Include(v => v.VehicleMake)
                                    .FirstOrDefaultAsync(v => v.VehicleModelId == id);
            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.VehicleMakes = new SelectList(await DbContext.VehicleMakes.ToListAsync(), 
                        "VehicleMakeId", "Abrv");
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

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await DbContext.VehicleModels.FindAsync(id);
            ViewBag.VehicleMakes = new SelectList(await DbContext.VehicleMakes.ToListAsync(),
                        "VehicleMakeId", "Abrv");

            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleModelToUpdate = await DbContext.VehicleModels
                                        .FirstOrDefaultAsync(v => v.VehicleModelId == id);
            if (await TryUpdateModelAsync(
                vehicleModelToUpdate, "", v => v.VehicleMakeId, v => v.Name, v => v.Abrv))
            {
                try
                {
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(vehicleModelToUpdate);
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleModel = await DbContext.VehicleModels.Include(v => v.VehicleMake)
                                    .FirstOrDefaultAsync(v => v.VehicleModelId == id);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleModel = await DbContext.VehicleModels.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }
            try
            {
                DbContext.VehicleModels.Remove(vehicleModel);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vehicleModel);
        }
    }
}
