using Microsoft.AspNetCore.Mvc;

namespace VehicleWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
