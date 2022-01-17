using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace VehicleWebAppService
{
    public class VehicleModelService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleModelService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<PaginatedList<VehicleModel>> GetVehicleModelsBy(
            string sortOrder, string searchString, int? pageNumber)
        {
            var vehicleModels = from v in DbContext.VehicleModels
                               select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.VehicleMake.Name.Contains(
                        searchString) || v.VehicleMake.Abrv.Contains(searchString));
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
            int pageSize = 10;
            return await PaginatedList<VehicleModel>.CreateAsync(
                vehicleModels.Include(v => v.VehicleMake).AsNoTracking(), 
                        pageNumber ?? 1, pageSize);
        }

        public async Task<VehicleModel> GetVehicleModel(int? id)
        {
            var vehicleModel = await DbContext.VehicleModels.Include(v => v.VehicleMake)
                                    .FirstOrDefaultAsync(v => v.VehicleModelId == id);
            return vehicleModel;
        }

        public async Task<List<VehicleModel>> GetAllVehicleModels()
        {
            return await DbContext.VehicleModels.ToListAsync();
        }

        public async Task AddVehicleModel(VehicleModel vehicleModel)
        {
            await DbContext.AddAsync(vehicleModel);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateVehicleModel()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteVehicleModel(int? id)
        {
            var vehicleModel = await GetVehicleModel(id);
            DbContext.VehicleModels.Remove(vehicleModel);
            await DbContext.SaveChangesAsync();
        }
    }
}
