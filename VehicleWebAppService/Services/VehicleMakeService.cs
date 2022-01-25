using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Helpers;
using VehicleWebAppService.Interfaces;
using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebAppService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleDbContext DbContext;
        private readonly IPaging Paging;

        public VehicleMakeService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;
            Paging = new Paging(dbContext);
        }

        public async Task<IPagedList<VehicleMake>> GetVehicleMakesBy(
            string sortOrder, string filter, int? pageNumber)
        {
            return await Paging.GetVehicleMakesBy(sortOrder, filter, pageNumber);
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

        public async Task UpdateVehicleMake(VehicleMake vehicleMake)
        {
            DbContext.Update(vehicleMake);
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
