using Microsoft.AspNetCore.Http;
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
            return View(await DbContext.VehicleModels.Include(v => v.VehicleMake).ToListAsync());
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
                ModelState.AddModelError("", ex.ToString());
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
