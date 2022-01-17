using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using VehicleWebApp;

namespace VehicleWebAppService
{
    public class VehicleService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;  
        }

        public async Task<PaginatedList<VehicleMake>> GetVehicleMakes(
            string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            var vehicleMakes = from v in DbContext.VehicleMakes
                               select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(v => v.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleMakeId);
                    break;
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Name);
                    break;
                case "name_asc":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Name);
                    break;
                case "abrv_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.Abrv);
                    break;
                case "abrv_asc":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.Abrv);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleMakeId);
                    break;
            }
            int pageSize = 5;
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
        
    }
}
