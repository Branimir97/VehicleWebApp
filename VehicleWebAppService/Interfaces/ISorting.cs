using System.Collections.Generic;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.Interfaces
{
    interface ISorting
    {
        public IEnumerable<VehicleMake> SortVehicleMakes(
            string sortOrder, IEnumerable<VehicleMake> VehicleMakes);
        public IEnumerable<VehicleModel> SortVehicleModels(
            string sortOrder, IEnumerable<VehicleModel> VehicleModels);
    }
}
