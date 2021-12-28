using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions options) : base(options) { }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
