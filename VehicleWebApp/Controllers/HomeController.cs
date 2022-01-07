using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;

namespace VehicleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleDbContext VehicleDbContext;

        public HomeController(VehicleDbContext vehicleDbContext)
        {
            VehicleDbContext = vehicleDbContext;
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}
