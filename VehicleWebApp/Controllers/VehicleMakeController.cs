using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await DbContext.VehicleMakes.ToListAsync());
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
