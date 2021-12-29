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
                new VehicleMake { Id = 1, Name = "BMW", Abrv = "BMW" },
                new VehicleMake { Id = 2, Name = "Ford", Abrv = "Ford" },
                new VehicleMake { Id = 3, Name = "Audi", Abrv = "Audi" },
                new VehicleMake { Id = 4, Name = "Porsche", Abrv = "Porsche" },
                new VehicleMake { Id = 5, Name = "Fiat", Abrv = "Fiat" }
            );

            //modelBuilder.Entity<VehicleModel>().HasData(
            //    new VehicleModel { Id = 1, Name = "Focus", VehicleMake = VehicleMakes[1], Abrv = "Focus" },
            //    new VehicleModel { Id = 2, Name = "530xd", VehicleMake = VehicleMakes[0], Abrv = "F10" },
            //    new VehicleModel { Id = 3, Name = "Cayenne 3.0", VehicleMake = VehicleMakes[3], Abrv = "Cayenne" },
            //    new VehicleModel { Id = 4, Name = "Grande Punto", VehicleMake = VehicleMakes[4], Abrv = "Punto" },
            //    new VehicleModel { Id = 5, Name = "A4 2.0TDI", VehicleMake = VehicleMakes[2], Abrv = "B8.5" }
            //);
        }
    }
}
