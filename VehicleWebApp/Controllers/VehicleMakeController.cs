using Microsoft.AspNetCore.Http;
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

        public VehicleMake VehicleMake { get; set; }

        public VehicleMakeController(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: VehicleMakeController
        public async Task<IActionResult> Index()
        {
            var vehicleMakes = await DbContext.VehicleMakes.ToListAsync();
            return View(vehicleMakes);
        }

        // GET: VehicleMakeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleMakeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakeController/Create
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
            return View();
        }

        // GET: VehicleMakeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleMakeController/Edit/5
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

        // GET: VehicleMakeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleMakeController/Delete/5
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
