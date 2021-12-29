using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;

namespace VehicleWebApp.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleDbContext VehicleDbContext;
        [BindProperty]
        public VehicleMake VehicleMake { get; set; }

        public VehicleMakeController(VehicleDbContext vehicleDbContext)
        {
            VehicleDbContext = vehicleDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await VehicleDbContext.AddAsync(VehicleMake);
            VehicleDbContext.SaveChanges();
            return RedirectToRoute("Index");
        }
     }
}
