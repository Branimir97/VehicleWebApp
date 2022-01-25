using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;

namespace VehicleWebAppService
{
    public class VehicleModelService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleModelService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IPagedList<VehicleModel>> GetVehicleModelsBy(
            string sortOrder, string searchString, int? pageNumber)
        {
            var vehicleModels = from v in DbContext.VehicleModels
                                select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                vehicleModels = vehicleModels.Where(v => v.VehicleMake.Name.Contains(
                        searchString) || v.VehicleMake.Abrv.Contains(searchString));
            }
            vehicleModels = sortOrder switch
            {
                "id_desc" => vehicleModels.OrderByDescending(v => v.VehicleModelId),
                "veh_make_asc" => vehicleModels.OrderBy(v => v.VehicleMake.Name),
                "veh_make_desc" => vehicleModels.OrderByDescending(v => v.VehicleMake.Name),
                "veh_abrv_asc" => vehicleModels.OrderBy(v => v.VehicleMake.Abrv),
                "veh_abrv_desc" => vehicleModels.OrderByDescending(v => v.VehicleMake.Abrv),
                "model_asc" => vehicleModels.OrderBy(v => v.Name),
                "model_desc" => vehicleModels.OrderByDescending(v => v.Name),
                "abrv_asc" => vehicleModels.OrderBy(v => v.Abrv),
                "abrv_desc" => vehicleModels.OrderByDescending(v => v.Abrv),
                _ => vehicleModels.OrderBy(v => v.VehicleModelId),
            };
            int pageSize = 10;
            return await vehicleModels.ToPagedListAsync(pageNumber ?? 1, 10);
        }

        public async Task<VehicleModel> GetVehicleModel(int? id)
        {
            var vehicleModel = await DbContext.VehicleModels.Include(v => v.VehicleMake)
                                    .FirstOrDefaultAsync(v => v.VehicleModelId == id);
            return vehicleModel;
        }

        public async Task<List<VehicleMake>> GetAllVehicleMakes()
        {
            return await DbContext.VehicleMakes.ToListAsync();
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
