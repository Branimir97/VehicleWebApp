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
        }
    }
}
