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
                new VehicleMake { VehicleMakeId = 1, Name = "BMW", Abrv = "BMW" },
                new VehicleMake { VehicleMakeId = 2, Name = "Ford", Abrv = "Ford" },
                new VehicleMake { VehicleMakeId = 3, Name = "Audi", Abrv = "Audi" },
                new VehicleMake { VehicleMakeId = 4, Name = "Porsche", Abrv = "Porsche" },
                new VehicleMake { VehicleMakeId = 5, Name = "Fiat", Abrv = "Fiat" },
                new VehicleMake { VehicleMakeId = 6, Name = "BMW", Abrv = "BMW" },
                new VehicleMake { VehicleMakeId = 7, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { VehicleMakeId = 8, Name = "Volkswagen", Abrv = "VW" },
                new VehicleMake { VehicleMakeId = 9, Name = "Opel", Abrv = "Opel" },
                new VehicleMake { VehicleMakeId = 10, Name = "General Motors", Abrv = "GM" }
            );
        }
    }
}
