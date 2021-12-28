using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.DAL
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { Name = "BMW", Abrv = "BMW" },
                new VehicleMake { Name = "Ford", Abrv = "Ford" },
                new VehicleMake { Name = "Audi", Abrv = "Audi" },
                new VehicleMake { Name = "Porsche", Abrv = "Porsche" },
                new VehicleMake { Name = "Fiat", Abrv = "Fiat" }
            );

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Name = "Focus", MakeId = , Abrv = "Focus" },
                new VehicleModel { Name = "530xd", MakeId = , Abrv = "F10" },
                new VehicleModel { Name = "Cayenne 3.0", MakeId = , Abrv = "Cayenne" },
                new VehicleModel { Name = "Grande Punto", MakeId = , Abrv = "Punto" },
                new VehicleModel { Name = "A4 2.0TDI", MakeId = , Abrv = "B8.5" }
            );
        }
    }
}
