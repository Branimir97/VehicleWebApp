using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;
using VehicleWebAppService.Helpers;
using VehicleWebAppService.Interfaces;

namespace VehicleWebAppService
{
    public class VehicleModelService
    {
        private readonly VehicleDbContext DbContext;
        private readonly IPaging Paging;

        public VehicleModelService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
            Paging = new Paging(DbContext);
        }

        public async Task<IPagedList<VehicleModel>> GetVehicleModelsBy(
            string sortOrder, string searchString, int? pageNumber)
        {
           return await Paging.GetVehicleModelsBy(sortOrder, searchString, pageNumber);
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
