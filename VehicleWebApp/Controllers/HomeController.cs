using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Models;
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

        public async Task<ViewResult> Index()
        {
            var vehicleMakes = await VehicleDbContext.VehicleMakes.ToListAsync();
            return View(vehicleMakes);
        }
    }
}
