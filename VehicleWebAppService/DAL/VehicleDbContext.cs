using Microsoft.EntityFrameworkCore;
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
                new VehicleMake { VehicleMakeId = 1, Name = "Bayerische Motoren Werke AG", Abrv = "BMW" },
                new VehicleMake { VehicleMakeId = 2, Name = "Ford Motor Company", Abrv = "Ford" },
                new VehicleMake { VehicleMakeId = 3, Name = "Audi AG", Abrv = "Audi" },
                new VehicleMake { VehicleMakeId = 4, Name = "Fiat S.p.A.", Abrv = "Fiat" },
                new VehicleMake { VehicleMakeId = 5, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { VehicleMakeId = 6, Name = "Opel Automobile GmbH", Abrv = "Opel" },
                new VehicleMake { VehicleMakeId = 7, Name = "General Motors", Abrv = "GM" },
                new VehicleMake { VehicleMakeId = 8, Name = "Hyundai Motor Company", Abrv = "Hyundai" },
                new VehicleMake { VehicleMakeId = 9, Name = "Honda Motor Company", Abrv = "Honda" },
                new VehicleMake { VehicleMakeId = 10, Name = "Toyota Motor Corporation", Abrv = "Toyota" },
                new VehicleMake { VehicleMakeId = 11, Name = "Mercedes-Benz", Abrv = "Mercedes" },
                new VehicleMake { VehicleMakeId = 12, Name = "Peugeot S.A.", Abrv = "Peugeot" }     
            );
        }
    }
}
