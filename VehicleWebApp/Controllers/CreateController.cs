using Microsoft.AspNetCore.Mvc;
using VehicleWebAppService.DAL;

namespace VehicleWebApp.Controllers
{
    public class CreateController : Controller
    {
        private readonly VehicleDbContext VehicleDbContext;

        public CreateController(VehicleDbContext vehicleDbContext)
        {
            VehicleDbContext = vehicleDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
     }
}
