using System.Threading.Tasks;
using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebAppService.Interfaces
{
    interface IVehicleMakeService
    {
        public Task<IPagedList<VehicleMake>> GetVehicleMakesBy(
            string sortOrder, string filter, int? pageNumber);
        public Task<VehicleMake> GetVehicleMake(int? id);
        public Task AddVehicleMake(VehicleMake vehicleMake);
        public Task UpdateVehicleMake(VehicleMake vehicleMake);
        public Task DeleteVehicleMake(int? id);
    }
}
