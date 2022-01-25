using System.Collections.Generic;
using VehicleWebAppService.Models;

namespace VehicleWebAppService.Interfaces
{
    interface IFiltering
    {
        public IEnumerable<VehicleMake> FilterVehicleMakes(string filter);
    }
}
