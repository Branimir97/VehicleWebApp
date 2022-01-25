using System.Threading.Tasks;
using VehicleWebAppService.Models;
using X.PagedList;

namespace VehicleWebAppService.Interfaces
{
    interface IPaging
    {
        public Task<IPagedList<VehicleMake>> GetVehicleMakesBy(
            string sortOrder, string filter, int? pageNumber);
        public Task<IPagedList<VehicleModel>> GetVehicleModelsBy(
            string sortOrder, string filter, int? pageNumber);
    }
}
