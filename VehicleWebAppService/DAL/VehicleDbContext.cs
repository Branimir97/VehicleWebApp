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
                new VehicleMake { Id = 5, Name = "Fiat", Abrv = "Fiat" },
                new VehicleMake { Id = 6, Name = "BMW", Abrv = "BMW" },
                new VehicleMake { Id = 7, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { Id = 8, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { Id = 9, Name = "Opel", Abrv = "Opel" },
                new VehicleMake { Id = 10, Name = "General Motors", Abrv = "GM" }
            );

            //modelBuilder.Entity<VehicleModel>().HasData(
            //    new VehicleModel { Id = 1, VehicleMake = 1, Name="530xd", Abrv="F10"}
            //);
        }
    }
}
