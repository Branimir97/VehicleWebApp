using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VehicleWebAppService
{
    public class VehicleModelService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleModelService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<PaginatedList<VehicleModel>> GetVehicleModels(
            string sortOrder, string searchString, int? pageNumber)
        {
            var vehicleModels = from v in DbContext.VehicleModels
                               select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.VehicleMake.Name.Contains(searchString)
                                    || v.VehicleMake.Abrv.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleModelId);
                    break;
                case "veh_make_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleMake.Name);
                    break;
                case "veh_make_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleMake.Name);
                    break;
                case "veh_abrv_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleMake.Abrv);
                    break;
                case "veh_abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.VehicleMake.Abrv);
                    break;
                case "model_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Name);
                    break;
                case "model_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Name);
                    break;
                case "abrv_asc":
                    vehicleModels = vehicleModels.OrderBy(v => v.Abrv);
                    break;
                case "abrv_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.Abrv);
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(v => v.VehicleModelId);
                    break;
            }
            int pageSize = 2;
            return await PaginatedList<VehicleModel>.CreateAsync(
                vehicleModels.Include(v => v.VehicleMake).AsNoTracking(), pageNumber ?? 1, pageSize);

        }

        public async Task<VehicleModel> GetVehicleModel(int? id)
        {
            var vehicleModel = await DbContext.VehicleModels.Include(v => v.VehicleModels).
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
