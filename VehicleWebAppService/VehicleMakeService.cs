using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;

namespace VehicleWebAppService
{
    public class VehicleMakeService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleMakeService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;  
        }

        public async Task<PaginatedList<VehicleMake>> GetVehicleMakesBy(
            string sortOrder, string searchString, int? pageNumber)
        {
            var vehicleMakes = from v in DbContext.VehicleMakes
                               select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(v => v.Name.Contains(searchString));
            }

            vehicleMakes = sortOrder switch
            {
                "id_desc" => vehicleMakes.OrderByDescending(v => v.VehicleMakeId),
                "name_desc" => vehicleMakes.OrderByDescending(v => v.Name),
                "name_asc" => vehicleMakes.OrderBy(v => v.Name),
                "abrv_desc" => vehicleMakes.OrderByDescending(v => v.Abrv),
                "abrv_asc" => vehicleMakes.OrderBy(v => v.Abrv),
                _ => vehicleMakes.OrderBy(v => v.VehicleMakeId),
            };
            int pageSize = 10;
            return await PaginatedList<VehicleMake>.CreateAsync(vehicleMakes.AsNoTracking(),
                        pageNumber ?? 1, pageSize);
        }

        public async Task<VehicleMake> GetVehicleMake(int? id) 
        {
            var vehicleMake = await DbContext.VehicleMakes.Include(v => v.VehicleModels).
                                FirstOrDefaultAsync(v => v.VehicleMakeId == id);
            return vehicleMake;
        }

        public async Task AddVehicleMake(VehicleMake vehicleMake)
        {
            await DbContext.AddAsync(vehicleMake);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateVehicleMake()
        {
            await DbContext.SaveChangesAsync();
        }
        
        public async Task DeleteVehicleMake(int? id)
        {
            var vehicleMake = await GetVehicleMake(id);
            DbContext.VehicleMakes.Remove(vehicleMake);
            await DbContext.SaveChangesAsync();
        }
    }
}
