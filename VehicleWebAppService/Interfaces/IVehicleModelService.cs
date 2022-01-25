using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebAppService.Interfaces
{
    interface IVehicleModelService
    {
        public Task<IPagedList<VehicleModel>> GetVehicleModelsBy(
            string sortOrder, string searchString, int? pageNumber);
        public Task<VehicleModel> GetVehicleModel(int? id);
        public Task<List<VehicleMake>> GetAllVehicleMakes();
        public Task AddVehicleModel(VehicleModel vehicleModel);
        public Task UpdateVehicleModel();
        public Task DeleteVehicleModel(int? id);
    }
}
