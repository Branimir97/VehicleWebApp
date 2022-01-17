using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VehicleWebAppService.DAL;
using VehicleWebAppService.Models;

namespace VehicleWebAppService
{
    public class VehicleService
    {
        private readonly VehicleDbContext DbContext;

        public VehicleService(VehicleDbContext dbContext)
        {
            DbContext = dbContext;  
        }

        public async Task<VehicleMake> GetVehicleMakeDetails(int? id) 
        {
            var vehicleMake = await DbContext.VehicleMakes.Include(v => v.VehicleModels).
                                FirstOrDefaultAsync(v => v.VehicleMakeId == id);
            return vehicleMake;
        }
    }
}
