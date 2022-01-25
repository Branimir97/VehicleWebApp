using System.Threading.Tasks;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.Interfaces
{
    interface IVehicleMakeService
    {
        public Task<PaginatedList<VehicleMake>> GetVehicleMakesBy(string sortOrder, string filter, int? pageNumber)
        public Task<VehicleMake> GetVehicleMake(int? id);
        public Task AddVehicleMake(VehicleMake vehicleMake);
        public Task UpdateVehicleMake();
        public Task DeleteVehicleMake(int? id);
    }
}
